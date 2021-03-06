using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    private float spawnRate = 1.0f;

    private int score;

    public bool isGameActive;

    public Button retryButton;

    public GameObject titleScreen;
   
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI gameOverText;

    private PlayerController playercontroller;

    // Start is called before the first frame update
    void Start()
    {
     
    }

   IEnumerator SpawnTarget()
   {
       while(isGameActive) // makes a function run indefinatly
       {
         yield return new WaitForSeconds(spawnRate);
         int index = Random.Range(0,targets.Count);
         Instantiate(targets[index]);
       }
   }   

   public void UpdateScore(int scoreToAdd)
   {
     score += scoreToAdd;
     scoreText.text = "Score: " + score;
   }

 public void GameOver()
 {
   if(playercontroller(isGameOver = true))
   {
      gameOverText.gameObject.SetActive(true);
     isGameActive = false;
     retryButton.gameObject.SetActive(true);
   }
  
 }

 public void ResetGame()
 {
   SceneManager.LoadScene(SceneManager.GetActiveScene().name);
 }

 public void StartGame(int difficulty)
 {
    isGameActive = true;
    titleScreen.gameObject.SetActive(false);
    spawnRate /= difficulty;
    UpdateScore(0);
    scoreText.text = " Score: " + score;
    StartCoroutine(SpawnTarget());  
 }
}
