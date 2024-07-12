using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicPathFollower : MonoBehaviour
{
    // The start and end points of the parabolic path
    public Transform startPoint;
    public Transform endPoint;

    // The height of the parabola
    public float height = 5.0f;

    // The duration of the travel from start to end
    public float travelTime = 2.0f;

    private float elapsedTime = 0.0f;
    private Vector3 initialPosition;

    void Start()
    {
        if (startPoint == null || endPoint == null)
        {
            Debug.LogError("Start point or End point is not assigned.");
            return;
        }

        initialPosition = transform.position;
    }

    void Update()
    {
        if (startPoint == null || endPoint == null)
            return;

        elapsedTime += Time.deltaTime;
        float t = elapsedTime / travelTime;

        if (t > 1.0f)
        {
            t = 1.0f;
        }

        Vector3 currentPosition = CalculateParabolicPoint(startPoint.position, endPoint.position, height, t);
        transform.position = currentPosition;

        if (t == 1.0f)
        {
            // Reset the elapsed time to start the travel again if needed
            elapsedTime = 0.0f;
        }
    }

    Vector3 CalculateParabolicPoint(Vector3 start, Vector3 end, float height, float t)
    {
        // Calculate the parabolic point at time t
        float u = 1 - t;
        Vector3 position = u * start + t * end + t * u * Vector3.up * height;

        return position;
    }
}
