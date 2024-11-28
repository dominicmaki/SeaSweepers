using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public float moveAmount = 1.0f;
    private Vector3 targetPosition; //target position sprite will move to
    [SerializeField] Diver diver;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update(){
        Vector3 movement = Vector3.zero;
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

        diver.Move(movement);
    }
}