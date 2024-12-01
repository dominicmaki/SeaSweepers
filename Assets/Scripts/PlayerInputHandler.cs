using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public float moveAmount = 1.0f;
    private Vector3 targetPosition; // Target position sprite will move to
    [SerializeField] private Diver diver; // Reference to Diver script
    [SerializeField] private OxygenManager oxygenManager; // Reference to OxygenManager script

    void Start()
    {
        targetPosition = transform.position;

        // Ensure the OxygenManager is assigned
        if (oxygenManager == null)
        {
            Debug.LogError("OxygenManager not assigned in the Inspector.");
        }
    }

    void Update()
    {
        MoveDiverWithMouse();
        Vector3 movement = Vector3.zero;

        // Handle movement inputs
        if (Input.GetKey(KeyCode.A)) movement += new Vector3(-1, 0, 0);
        if (Input.GetKey(KeyCode.D)) movement += new Vector3(1, 0, 0);
        if (Input.GetKey(KeyCode.W)) movement += new Vector3(0, 1, 0);
        if (Input.GetKey(KeyCode.S)) movement += new Vector3(0, -1, 0);

        if (Input.GetKeyDown(KeyCode.R))
        {
            // Attempt to upgrade by deducting gold
            if (GoldManager.Instance != null && oxygenManager != null)
            {
                if (GoldManager.Instance.DeductGold(100)) // Check if there's enough gold
                {
                    oxygenManager.RefillOxygen(30); // Refill oxygen by 30
                    Debug.Log("Upgrade purchased! Remaining Gold: " + GoldManager.Instance.totalGold);
                }
                else
                {
                    Debug.Log("Not enough gold to upgrade!");
                }
            }
            else
            {
                Debug.LogWarning("GoldManager or OxygenManager is missing.");
            }
        }

        // Move the Diver (if necessary)
        if (diver != null)
        {
            diver.Move(movement);
        }
        else
        {
            Debug.LogError("Diver not assigned in the Inspector.");
        }
    }

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
