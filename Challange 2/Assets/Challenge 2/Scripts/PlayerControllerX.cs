using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float timer;
    public float timeLimit = 1.0f;
    // Update is called once per frame
    void Update()
    {
       //Creates Timer
        timer += Time.deltaTime;
        // On spacebar press, send dog with a timer limit
        if (Input.GetKeyDown(KeyCode.Space)&& timer > timeLimit)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            timer = 0;
        }
    }
}
