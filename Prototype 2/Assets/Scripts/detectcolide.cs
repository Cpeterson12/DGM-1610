using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectcolide : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
        //destroy this object
        Destroy(gameObject);
        //destroy other object that collides with trigger
        Destroy(other.gameObject);
    }
}
