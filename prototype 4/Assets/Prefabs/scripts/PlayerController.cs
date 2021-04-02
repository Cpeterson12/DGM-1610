using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private GameObject focalPoint;
    private Rigidbody playerRb;

    public bool hasPowerup;
    public float powerupStrength =16.0f;

    public GameObject powerupIndicator;

    // Start is called before the first frame update
    void Start()
    {
       playerRb = GetComponent<Rigidbody>();
       focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * Time.deltaTime);

        powerupIndicator.transform.position = transform.position + new Vector3(0, 0.5f, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        // Pickup and remove powerup
        if(other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            Debug.Log("POWER");
            StartCoroutine(PowerupCountdownRutine());

            powerupIndicator.gameObject.SetActive(true);
        }
    }

  private void OnCollisionEnter(Collision collision)
  {
      if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
      {
          // Gets the enemy's rigidbody
          Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
          //Gets the position of the enemy in relation to the player
          Vector3 awayFromplayer = (collision.gameObject.transform.position - transform.position);
          // report player collision with the powerup
          Debug.Log("Player has collided with " + collision.gameObject + "with powerup set to " + hasPowerup);
          // Kicks the enemy away from the player when they collide with the player.
          enemyRigidbody. AddForce(awayFromplayer * powerupStrength, ForceMode.Impulse);
      }
  }
  IEnumerator PowerupCountdownRutine()
  {
      yield return new WaitForSeconds(7); hasPowerup = false;
      powerupIndicator.gameObject.SetActive (false);
  }
}
