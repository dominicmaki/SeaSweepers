using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {   
        Debug.Log("Collided - Trash");
        if(other.CompareTag("Diver")){
            Debug.Log("Inside compare tag - Trash");
            GoldCounter gold = other.GetComponent<GoldCounter>();
            gold.Count(10);
            Destroy(gameObject);
        }
    }
}
