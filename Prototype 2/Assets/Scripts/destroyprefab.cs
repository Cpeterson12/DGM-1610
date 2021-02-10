using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyprefab : MonoBehaviour

{
    private float topBound = 35;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > 40)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < -15)
        {
           Debug.Log("GAME OVER!");
           Destroy(gameObject);
        }
    }
}
