﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float hInput;

    public float speed = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
      
      transform.Translate(Vector3.right * hInput * Time.deltaTime * speed);

        if(transform.position.x < -10)
        {
         transform.position = new Vector3(-10, transform.position.y, transform.position.z);
        }
        

    }
}
