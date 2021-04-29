using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button retryButton;

    public bool isGameActive;

    public GameObject titleScreen;

    public TextMeshProUGUI gameOverText;

    private Enemy1 enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
  {
       gameOverText.gameObject.SetActive(true);
       isGameActive = false;
       retryButton.gameObject.SetActive(true);
  }

  public void ResetGame()
  {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
   
   public void StartGame(int begin)
 {
     isGameActive = true;
     titleScreen.gameObject.SetActive(false);

 }
}
