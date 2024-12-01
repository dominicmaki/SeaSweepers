using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diver : MonoBehaviour
{
    Rigidbody2D rb;
    [Header("Movement")]
    [SerializeField] float speed = 10f;

    //[SerializeField] int gold = 0;
    // Start is called before the first frame update
    
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector3 movement)
    {
        rb.velocity = movement * speed;
    }
}