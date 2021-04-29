using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
          Destroy(gameObject, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
          
    }

    void OnCollisionEnter(Collision other)
    {
         if (other.gameObject.CompareTag("obstacle"))
        Destroy(other.gameObject);
    }
}
