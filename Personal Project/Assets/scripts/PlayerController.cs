using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float hInput;
    public float jumpForce;
    public float gravityModifier = 1.5f;
    public float speed = 10.0f;
    private Rigidbody playerRb;

    public GameObject projectilePrefab;
    public float swordDuration = 0.5f;

    public bool isOnGround = true;
    public bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerRb = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {
        //Player controls
      if (Input.GetKey(KeyCode.D) && !isGameOver)
      {
         transform.Translate(Vector3.right * Time.deltaTime * speed);
      }

       if (Input.GetKey(KeyCode.A) && !isGameOver)
      {
         transform.Translate(Vector3.left * Time.deltaTime * speed);
      }

      if (Input.GetKeyDown(KeyCode.W) && isOnGround && !isGameOver)
      {
          playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
          isOnGround = false;
      }
      if (Input.GetKeyDown(KeyCode.Space) && !isGameOver)
      {
         Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
      }
      
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Goal"))
        {
         Destroy(other.gameObject);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;

        if(collision.gameObject.CompareTag("ground"))
        {
            isOnGround = true;
        }
        else if(collision.gameObject.CompareTag("obstacle"))
        {
            isGameOver = true;
            Debug.Log("GAME OVER! ! !");

        }
    
    }

    
}
