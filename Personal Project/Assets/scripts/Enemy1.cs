using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float speed;
    public Rigidbody enemyRb;
    private GameObject player;
    
   

    // Start is called before the first frame update
    void Start()
    {
      enemyRb = GetComponent<Rigidbody>();
      player = GameObject.Find("Player");
    }

    // Update is called once per frame
    public void Update()
    {
      Vector3 lookDirection = (player.transform.position - transform.position).normalized;
      enemyRb.AddForce( lookDirection * speed * Time.deltaTime);
    }

}

