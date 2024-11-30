using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class OxygenManager : MonoBehaviour
{
    public Slider oxygenSlider;  // Reference to the Slider component
    public TMP_Text oxygenText;      // Reference to the Text component for displaying remaining time
    public float maxOxygen = 30f; // Maximum oxygen level
    private float currentOxygen; // Current oxygen level
    public float depletionRate = 1f; // Oxygen depletion rate (seconds)

    void Start()
    {
        currentOxygen = maxOxygen; // Set oxygen to full
        if (oxygenSlider != null)
        {
            oxygenSlider.maxValue = maxOxygen; // Set slider max value
            oxygenSlider.value = currentOxygen; // Initialize slider value
        }

        UpdateOxygenText(); // Initialize the text display
    }

    void Update()
    {
        // Decrease oxygen over time
        currentOxygen -= Time.deltaTime / depletionRate;

        if (oxygenSlider != null)
        {
            oxygenSlider.value = currentOxygen; // Update the slider UI
        }

        UpdateOxygenText(); // Update the text display

        if (currentOxygen <= 0)
        {
            Debug.Log("Out of Oxygen!"); 
            SceneManager.LoadScene("MainMenu");
            currentOxygen = 0;
            // Handle player death or other logic here
        }
    }

    public void RefillOxygen(float amount)
    {
        currentOxygen += amount;
        if (currentOxygen > maxOxygen)
        {
            currentOxygen = maxOxygen;
        }

        UpdateOxygenText(); // Update the text display after refilling
    }

    private void UpdateOxygenText()
    {
        if (oxygenText != null)
        {
            // Display the remaining oxygen time rounded to one decimal place
            oxygenText.text = $"Oxygen: {currentOxygen:F1} sec";
        }
    }
}
