using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public int score;
    public TMP_Text scoreText;
    public GameObject GameOverScreen;

    [ContextMenu("Increase Score")] // Allow to test the function, click on three points on Script scomponent, click on Name of function
    public void addScore(int addScore)
    {
        score += addScore;
        scoreText.text = score.ToString();
    }

    public void gameOver()
    {
        GameOverScreen.SetActive(true);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
