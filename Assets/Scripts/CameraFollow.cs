using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform playerTransform; // Reference to the player or object to follow

    void Start()
    {
        // Optional: Ensure playerTransform is assigned if not already in Inspector
        if (playerTransform == null)
        {
            GameObject player = GameObject.FindWithTag("Player"); // Assuming the player is tagged as "Player"
            if (player != null)
            {
                playerTransform = player.transform;
            }
            else
            {
                Debug.LogError("Player not found. Make sure the player is tagged correctly.");
            }
        }
    }

    void LateUpdate() // Use LateUpdate to follow after all movement updates
    {
        if (playerTransform != null)
        {
            // Update camera position
            transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, -10);
        }
        else
        {
            Debug.LogError("Player transform not assigned!");
        }
    }
}
