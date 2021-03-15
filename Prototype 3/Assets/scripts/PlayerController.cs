using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    
    public float jumpForce;

    public float gravityMod;

    private Animator playerAnim;
 
 // bool is a true or false
    public bool isOnGround = true;
    public bool isGameOver = false;

    public ParticleSystem dirtParticles;
    public ParticleSystem explosionParticles;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMod;

        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       // && means both codes have to be true
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver)
        {
         playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);  
         isOnGround = false; 
         
         playerAnim.SetTrigger("Jump_trig");
         dirtParticles.Stop();
         playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;

        if(collision.gameObject.CompareTag("ground"))
        {
          isOnGround = true;
          dirtParticles.Play();
        }
        else if(collision.gameObject.CompareTag("obstacle"))
        {
           isGameOver = true;
           Debug.Log("GAME OVER!!!");
           playerAnim.SetBool("Death_b",true);
           playerAnim.SetInteger("DeathType_int", 1);
           explosionParticles.Play();
           dirtParticles.Stop();
           playerAudio.PlayOneShot(crashSound, 1.0f);
        }
       
    }
}
