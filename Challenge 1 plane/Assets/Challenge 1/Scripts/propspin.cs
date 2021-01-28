using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class propspin : MonoBehaviour
{
  // rotates prop
    public float turnSpeed = 200.0f;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
    }
}
