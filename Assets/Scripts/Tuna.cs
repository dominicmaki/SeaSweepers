using UnityEngine;

public class Tuna : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Diver"))
        {
            Debug.Log("Diver collided with Tuna");

            // Add gold to the GoldManager
            if (GoldManager.Instance != null)
            {
                GoldManager.Instance.AddGold(20);  // Add gold when colliding
                Debug.Log("Added 20 gold");
                Destroy(gameObject);  // Destroy the tuna object
            }
            else
            {
                Debug.LogError("GoldManager not found.");
            }
        }
    }
}
