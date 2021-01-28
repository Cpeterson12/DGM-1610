using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Access modifier, data type, name
    public float speed = 10.0f;

   public float turnSpeed = 20.0f;

    public float hInput;

    public float fInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //gathers the inputs for the controls
        hInput = Input.GetAxis("Horizontal");
        fInput = Input.GetAxis("Vertical");
      // makes the vehicle go forward and back
        transform.Translate(Vector3.forward * Time.deltaTime * speed * fInput);
       // makes vehicle go left and right
        transform.Rotate(Vector3.up, turnSpeed * hInput * Time.deltaTime);
    }
}
