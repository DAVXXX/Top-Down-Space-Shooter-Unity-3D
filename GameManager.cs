using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    public GameObject Titlescreen;

    private PlayerController playerController;


    public Text timerText;
    public Text scoreText;
    public Text Gameover;
    public Button restartButton;


    private int score;
    private float spawnRate = 1.0f;
    public float timeLeft;


    public bool isGameActive;

    //private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
      
       //playerController = gameObject.GetComponent<PlayerController>();

        //playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = ("Time: " + Mathf.Round(timeLeft));
        }
        if (timeLeft < 0)
        {
            
            GameOver();
           
        }
    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Vector3 spawnLocation = new Vector3(Random.Range(-12.4f, 10.1f), 1.5f, 30);
            Instantiate(targets[index], spawnLocation, targets[index].transform.rotation);
            
           
        }


    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }


    public void GameOver()
    {
        Gameover.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);

        
        


    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void StartGame(int difficulty)
    {
        isGameActive = true;
        spawnRate = spawnRate / difficulty;

        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);

        Titlescreen.gameObject.SetActive(false);
    }
}
