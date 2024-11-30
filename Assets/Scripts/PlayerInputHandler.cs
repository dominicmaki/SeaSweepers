using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public float moveAmount = 1.0f;
    private Vector3 targetPosition; // Target position sprite will move to
    [SerializeField] private Diver diver; // Reference to Diver script
    [SerializeField] private GoldCounter goldCounter; // Reference to GoldCounter script
    [SerializeField] private OxygenManager oxygenManager; // Reference to OxygenManager script
    private int totalGold = 150; // Example starting gold amount

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;

        // Ensure the GoldCounter and OxygenManager are assigned
        if (goldCounter == null)
        {
            goldCounter = GetComponent<GoldCounter>();
            if (goldCounter == null)
            {
                Debug.LogError("GoldCounter not assigned or found on this GameObject.");
            }
        }

        if (oxygenManager == null)
        {
            Debug.LogError("OxygenManager not assigned in the Inspector.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveDiverWithMouse();
        Vector3 movement = Vector3.zero;

        // Handle movement inputs
        if (Input.GetKey(KeyCode.A))
        {
            movement += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += new Vector3(1, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            movement += new Vector3(0, 1, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement += new Vector3(0, -1, 0);
        }

        // Handle upgrade logic
        if (Input.GetKey(KeyCode.R))
        {
            if (goldCounter != null && oxygenManager != null)
            {
                goldCounter.Upgrade(totalGold, oxygenManager);
            }
            else
            {
                Debug.LogWarning("Cannot upgrade: GoldCounter or OxygenManager is missing.");
            }
        }

        // Call Diver's Move method
        if (diver != null)
        {
            diver.Move(movement);
        }
        else
        {
            Debug.LogError("Diver not assigned in the Inspector.");
        }
    }

     // Function to make the Diver move smoothly towards the mouse position
    private void MoveDiverWithMouse()
    {
        // Get the mouse position in screen space
        Vector3 mousePosition = Input.mousePosition;

        // Convert the screen space position to world space
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Set the z-position to match the Diver's z-position (to avoid depth issues)
        worldMousePosition.z = transform.position.z;  // Ensure the z-value matches the Diver's z position

        // Smoothly move the Diver's position towards the mouse position
        diver.transform.position = Vector3.MoveTowards(diver.transform.position, worldMousePosition, 10f * Time.deltaTime);

        // Rotate the Diver to face the mouse pointer direction
        RotateDiverToFaceMouse(worldMousePosition);
    }

    // Function to make the Diver rotate to face the mouse
    private void RotateDiverToFaceMouse(Vector3 mousePosition)
    {
        // Calculate the direction vector from the Diver to the mouse position
        Vector3 direction = mousePosition - diver.transform.position;

        // Get the angle between the diver's current forward direction and the direction to the mouse
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply the rotation to the Diver
        diver.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
