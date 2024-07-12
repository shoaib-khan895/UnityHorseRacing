using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    // List of points to move to
    public List<Transform> points;

    // Speed for the object at each point
    public List<float> speeds;

    // List of Animator Controllers to set at specific points
    public List<RuntimeAnimatorController> animatorControllers;

    // Index of the current target point
    private int currentPointIndex = 0;

    // Reference to the Animator component
    private Animator animator;

    // Speed for smooth rotation
    public float rotationSpeed = 5.0f;

    void Start()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (points.Count == 0 || speeds.Count == 0)
            return;

        // Move towards the current target point
        Transform targetPoint = points[currentPointIndex];
        float step = speeds[currentPointIndex] * Time.deltaTime; // Use the speed for the current point
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, step);

        // Calculate the direction to look at
        Vector3 direction = targetPoint.position - transform.position;
        if (direction.sqrMagnitude > 0.001f) // Ensure the direction is not zero
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            // Smoothly rotate towards the target point
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Check if the object has reached the current target point
        if (Vector3.Distance(transform.position, targetPoint.position) < 0.001f)
        {
            // Set the Animator Controller at the current point if available
            if (currentPointIndex < animatorControllers.Count && animatorControllers[currentPointIndex] != null)
            {
                animator.runtimeAnimatorController = animatorControllers[currentPointIndex];
            }

            // Check if we have reached the last point
            if (currentPointIndex >= points.Count - 1)
            {
                // Stop moving when the final point is reached
                enabled = false;
                Debug.LogWarning("Object has reached the final point and stopped.");
            }
            else
            {
                // Move to the next point
                currentPointIndex++;
            }
        }
    }

    // For visualization in the editor
    void OnDrawGizmos()
    {
        if (points == null || points.Count < 2)
            return;

        for (int i = 0; i < points.Count - 1; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(points[i].position, points[i + 1].position);
        }
    }
}
