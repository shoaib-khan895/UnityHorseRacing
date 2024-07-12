using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    // The target for the camera to follow
    public Transform target;

    // The offset position from the target
    public Vector3 positionOffset;

    // The offset rotation from the target's rotation
    public Vector3 rotationOffset;

    // The speed of the smooth follow for position
    public float positionSmoothSpeed = 0.125f;

    // The speed of the smooth follow for rotation
    public float rotationSmoothSpeed = 5.0f;

    void LateUpdate()
    {
        // Check if the target is set
        if (target == null)
            return;

        // Calculate the desired position with the position offset
        Vector3 desiredPosition = target.position + target.TransformDirection(positionOffset);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, positionSmoothSpeed);
        transform.position = smoothedPosition;

        // Calculate the desired rotation with the rotation offset
        Quaternion targetRotation = target.rotation * Quaternion.Euler(rotationOffset);
        Quaternion smoothedRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSmoothSpeed * Time.deltaTime);
        transform.rotation = smoothedRotation;
    }
}
