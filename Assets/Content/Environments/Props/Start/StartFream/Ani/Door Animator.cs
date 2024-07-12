using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionChanger : MonoBehaviour
{
    // References to the objects whose positions and rotations will be changed
    [SerializeField] private Transform[] targetObjects;

    // The new position to set for the target objects
    [SerializeField] private Vector3 newPositionOnEnter;
    [SerializeField] private Vector3 newPositionOnExit;

    // The new rotation to set for the target objects (in Euler angles)
    [SerializeField] private Vector3 newRotationOnEnter;
    [SerializeField] private Vector3 newRotationOnExit;

    // Tag to identify the player
    [SerializeField] private string playerTag = "Player";

    // Method called when another collider enters the trigger collider attached to this GameObject
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag(playerTag))
        {
            foreach (Transform targetObject in targetObjects)
            {
                Debug.Log($"Position of {targetObject.name} is {targetObject.position}");
                Debug.Log($"Rotation of {targetObject.name} is {targetObject.rotation}");

                // Change the position of the target object
                targetObject.position = newPositionOnEnter;
                Debug.Log($"Position of {targetObject.name} changed to {newPositionOnEnter}");

                // Change the rotation of the target object
                targetObject.rotation = Quaternion.Euler(newRotationOnEnter);
                Debug.Log($"Rotation of {targetObject.name} changed to {newRotationOnEnter}");
            }
        }
    }

    // Method called when another collider exits the trigger collider attached to this GameObject
    private void OnTriggerExit(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag(playerTag))
        {
            foreach (Transform targetObject in targetObjects)
            {
                Debug.Log($"Position of {targetObject.name} is {targetObject.position}");
                Debug.Log($"Rotation of {targetObject.name} is {targetObject.rotation}");

                // Change the position of the target object
                targetObject.position = newPositionOnExit;
                Debug.Log($"Position of {targetObject.name} changed to {newPositionOnExit}");

                // Change the rotation of the target object
                targetObject.rotation = Quaternion.Euler(newRotationOnExit);
                Debug.Log($"Rotation of {targetObject.name} changed to {newRotationOnExit}");
            }
        }
    }
}
