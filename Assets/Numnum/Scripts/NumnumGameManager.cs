using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NumnumGameManager : MonoBehaviour
{
    int score;
    int number = 0;
    int previous_number = 0;
    int displayNumber = 0;

    [Header("Time")]
    [SerializeField] float limitTime;
    [SerializeField] float decTime;
    [SerializeField] float minTime;
    float timer;

    [Header("Texts")]
    public TMP_Text scoreText;
    public TMP_Text numText;
    public TMP_Text timeText;
    public TMP_Text Best_Score;
    public TMP_Text Best_Score_Over;

    [Header("Game Over")]
    public GameObject gameOverScreen;
    
    Color red = new Color(255, 0, 0, 255);
    Color green = new Color(0, 255, 0, 255);
    Color white = new Color(255, 255, 255, 255);

    bool resume = true;
    int best = 0;

    // Start is called before the first frame update
    void Start()
    {
        generateRandomNumber();
        if (PlayerPrefs.HasKey("Best")) {
            // best = PlayerPrefs.GetInt("Best");
            best = 1;
            Best_Score.text = "Best: " + best.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!resume) return;
        if (timer < limitTime) { timer += Time.deltaTime; }
        else gameOver();
    }

    void generateRandomNumber()
    {
        previous_number = number;
        while (previous_number == number)
            number = Random.Range(0, 10);
        displayNumber = number;
        generateMalus();
        numText.text = displayNumber.ToString();
    }

    void generateMalus()
    {
        int random = Random.Range(0, 7);
        if (random <= 2 && number != 9) {
            ++number;
            numText.color = red;
        } else if (random >= 5 && number != 0) {
            --number;
            numText.color = green;
        } else numText.color = white;
        numText.text = number.ToString();
    }

    public void PressKey(int key)
    {
        if (!resume) return;
        if (key == number) {
            scoreText.text = "Score: " + (++score).ToString();
            generateRandomNumber();
            limitTime -= decTime;
            if (limitTime < minTime) limitTime = minTime;
            timeText.text = limitTime.ToString() + "s";
            timer = 0;
        } else gameOver();
    }

    public void gameOver()
    {
        resume = false;
        gameOverScreen.SetActive(true);
        if (score > best) {
            best = score;
            PlayerPrefs.SetInt("Best", best);
            Best_Score_Over.enabled = true;
        } else {
            Best_Score_Over.enabled = false;
        }
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
