using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class SpawnManager : MonoBehaviour
{

    public GameObject[] enemyPrefabs;
    

    private float spawnRate = 1.0f;
    private int score;




    public Text scoreText;
    public GameObject Titlescreen;
    public Text Gameover;
    public Button restartButton;

    private PlayerController playerControllerScript;
    private DifficultyButton difficultyButton;

    public bool isGameActive;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            Vector3 spawnLocation = new Vector3(Random.Range(-12.4f, 10.1f), 1.5f, 30);
            int index = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[index], spawnLocation, enemyPrefabs[index].transform.rotation);
            
        }
    }
    



}
