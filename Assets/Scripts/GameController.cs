using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float startWait;
    public float spawnWait;
    public float waveWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    private int score;
    private bool gameOver;
    private bool restart;

    void Start() {
        score = 0;

        gameOver = false;
        restart = false;

        gameOverText.text = "";
        restartText.text = "";

        UpdateScore();

        StartCoroutine(SpawnWaves());
    }

    public void AddScore(int newScoreValue) {
        score += newScoreValue;
        UpdateScore();
    }

    public void GameOver() {
        gameOverText.text = "Game Over";
        gameOver = true;
    }

    void Update() {
        if(restart) {
            if(Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                // Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    void UpdateScore() {
        scoreText.text = "Score: " + score;
    }

    IEnumerator SpawnWaves() {
        yield return new WaitForSeconds(startWait);

        while (true) {
            for (int i = 0; i < hazardCount; i++) {
                createHazard();
                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds(waveWait);

            if (gameOver) {
                restartText.text = "Press 'R' to Restart";
                restart = true;
                break;
            }
        }
    }

    private GameObject createHazard() {
        float value = Random.Range(-spawnValues.x, spawnValues.x);

        Vector3 spawnPosition = new Vector3(value, spawnValues.y, spawnValues.z);
        Quaternion spawnRotation = Quaternion.identity;

        return Instantiate(hazard, spawnPosition, spawnRotation) as GameObject;
    }
}
