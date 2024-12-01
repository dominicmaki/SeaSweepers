using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    public static GoldManager Instance; // Singleton instance
    public int totalGold; // Tracks the total gold

    // Called when the script is first loaded or instantiated
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // Set the singleton instance
            DontDestroyOnLoad(gameObject); // Keep it persistent across scenes (optional)
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance exists
        }
    }

    // Method to add gold
    public void AddGold(int amount)
    {
        totalGold += amount;
        UpdateUI(); // Update the UI (if needed)
    }

    // Method to deduct gold (for upgrade)
    public bool DeductGold(int amount)
    {
        if (totalGold >= amount)
        {
            totalGold -= amount;
            UpdateUI(); // Update the UI (if needed)
            return true;
        }
        else
        {
            return false; // Not enough gold
        }
    }

    // Method to update the UI (if applicable)
    private void UpdateUI()
    {
        // Call a UI update method (e.g., updating the text display in GoldCounter)
        // For example:
        if (GoldCounter.Instance != null)
        {
            GoldCounter.Instance.Display(totalGold);
        }
    }
}
