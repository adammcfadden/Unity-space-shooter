using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
public class GameController : MonoBehaviour
{

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    private int scoreInt;
    public Text restartText;
    public Text gameOverText;
    private bool gameOver;
    private bool restart;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        
        scoreInt = 0;
        updateScore();

        StartCoroutine(SpawnWaves());
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (restart && Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);﻿
        } 
    }
    
	// Update is called once per frame
	IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds(startWait);
        
        while(true)
        {
            for(int i = 0; i<hazardCount; i++) 
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(hazard, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if(gameOver) {
                restartText.text = "Press 'R' to Restart";
                restart = true;
                break;
            }
        }
	}

    public void AddScore(int newScoreValue){
        scoreInt += newScoreValue;
        updateScore();
    }

    void updateScore() {
        scoreText.text = "Score: " + scoreInt;
    }

    public void GameOver() {
        gameOver = true;
        gameOverText.text = "Game Over";
    }
}
