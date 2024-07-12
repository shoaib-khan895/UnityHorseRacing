using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionAnimator : MonoBehaviour
{
    // Reference to the camera to be animated
    [SerializeField] private Camera targetCamera;

    // The new position to animate the camera to
    [SerializeField] private Vector3 newPosition;

    // The new rotation to animate the camera to (in Euler angles)
    [SerializeField] private Vector3 newRotation;

    // Duration of the animation
    [SerializeField] private float animationDuration = 1.0f;

    // Tag to identify the player
    [SerializeField] private string playerTag = "Player";

    // Method called when another collider enters the trigger collider attached to this GameObject
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag(playerTag))
        {
            
        
            // Start the coroutine to animate the camera position and rotation
            if (targetCamera != null)
            {
                Debug.Log(targetCamera.transform.position);
                Debug.Log(targetCamera.transform.rotation);
                StartCoroutine(AnimateCameraPositionAndRotation(targetCamera.transform.position, newPosition, targetCamera.transform.rotation, Quaternion.Euler(newRotation), animationDuration));
            }
            else
            {
                Debug.LogWarning("Target camera is not assigned.");
            }
        }
    }

    // Coroutine to animate the camera position and rotation
    private IEnumerator AnimateCameraPositionAndRotation(Vector3 startPosition, Vector3 endPosition, Quaternion startRotation, Quaternion endRotation, float duration)
    {
        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            // Lerp the camera's position
            targetCamera.transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            // Lerp the camera's rotation
            targetCamera.transform.rotation = Quaternion.Lerp(startRotation, endRotation, elapsedTime / duration);

            // Increase the elapsed time
            elapsedTime += Time.deltaTime;

            // Wait for the next frame
            yield return null;
        }

        // Ensure the final position and rotation are set
        targetCamera.transform.position = endPosition;
        targetCamera.transform.rotation = endRotation;
    }
}
