using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowAndRotate : MonoBehaviour
{
    // The target object the camera will follow and rotate with
    public Transform target;

    // The offset position relative to the target
    public Vector3 offset;

    // Speed of the smooth follow
    public float followSmoothSpeed = 0.125f;

    // Speed of the smooth rotation
    public float rotateSmoothSpeed = 5.0f;

    void LateUpdate()
    {
        if (target == null)
            return;

        // Follow the target's position with the offset
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, followSmoothSpeed);
        transform.position = smoothedPosition;

        // Rotate to match the target's rotation smoothly
        Quaternion targetRotation = target.rotation;
        Quaternion smoothedRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSmoothSpeed * Time.deltaTime);
        transform.rotation = smoothedRotation;
    }

    // For visualization in the editor
    void OnDrawGizmos()
    {
        if (target != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, target.position);
            Gizmos.DrawWireSphere(target.position + offset, 0.1f);
        }
    }
}
