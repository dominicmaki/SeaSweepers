using UnityEngine;

public class Trash : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Diver"))
        {
            Debug.Log("Diver collided with Trash");

            // Add gold to the GoldManager
            if (GoldManager.Instance != null)
            {
                GoldManager.Instance.AddGold(10);  // Add gold when colliding
                Debug.Log("Added 10 gold");
                Destroy(gameObject);  // Destroy the tuna object
            }
            else
            {
                Debug.LogError("GoldManager not found.");
            }
        }
    }
}
