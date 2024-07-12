using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;    // The target object the camera will follow
    public float smoothSpeed = 0.125f; // Speed of the camera's smoothing motion
    public Vector3 offset;      // Offset between the camera and the target object

    void FixedUpdate()
    {
        if (target != null)
        {
            // Define the desired position of the camera
            Vector3 desiredPosition = target.position + offset;

            // Smoothly interpolate between the current position and the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Apply the smoothed position to the camera
            transform.position = smoothedPosition;

            // Optionally, make the camera always look at the target
            transform.LookAt(target);
        }
    }
}
