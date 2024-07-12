using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    // Reference to the Animator component on the target object
    [SerializeField] private Animator targetAnimator;

    // The animation controller to set
    [SerializeField] private RuntimeAnimatorController animationController;

    // Tag to identify the player
    [SerializeField] private string playerTag = "Player";

    // Method called when another collider enters the trigger collider attached to this GameObject
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag(playerTag))
        {
            // Set the animation controller and play the default animation
            if (targetAnimator != null && animationController != null)
            {
                targetAnimator.runtimeAnimatorController = animationController;
                Debug.Log($"Animation controller {animationController.name} set on {targetAnimator.gameObject.name}");
            }
            else
            {
                Debug.LogWarning("Target Animator or Animation Controller is not assigned.");
            }
        }
    }
}
