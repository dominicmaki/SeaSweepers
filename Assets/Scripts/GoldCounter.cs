using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoldCounter : MonoBehaviour
{
    public TMP_Text DisplayText; // Reference to the TextMeshPro component
    private int totalGold = 0;   // Tracks the total gold
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Upgrade(int totalGold, OxygenManager oxygenManager)
    {
        if (totalGold >= 100)
        {
            totalGold -= 100; // Deduct the cost of the upgrade
            oxygenManager.RefillOxygen(30); // Refill oxygen by 30
        }
        else
        {
            Debug.Log("Not enough gold to upgrade!"); // Optional feedback
        }
    }   


    public void Count(int goldValue)
    {
        totalGold += goldValue; // Increment total gold
        if (DisplayText != null)
        {
            DisplayText.text = "Gold: " + totalGold.ToString();
        }
    }
}
