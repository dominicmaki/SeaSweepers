using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldCounter : MonoBehaviour
{
    public static GoldCounter Instance; // Singleton instance
    public TMP_Text DisplayText; // Reference to the TextMeshPro component

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

    // Method to update the UI with the total gold
    public void Display(int totalGold)
    {
        if (DisplayText != null)
        {
            DisplayText.text = $"Gold: {totalGold}";
        }
        else
        {
            Debug.LogError("DisplayText is not assigned!");
        }
    }
}
