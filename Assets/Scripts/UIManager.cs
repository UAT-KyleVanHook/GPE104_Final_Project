using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
   // public Image TimerImage;

    public TMP_Text scoreText;
    int currentScore;

    public TMP_Text livesText;
    int currentPlayerLives;

    //bool bTimeRanOut = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //start the timer
        //GameManager.instance.resetTimer();

        //set initial texts
        scoreText.text = "Score:";
        livesText.text = "Lives x";

       //get current player lives and score
        currentPlayerLives = GameManager.instance.playerLives;
        currentScore = GameManager.instance.score;

    }

    // Update is called once per frame
    void Update()
    {

        //UpdateTimer();

        UpdateScoreText();

        UpdateLivesCount();
    }

    ////updates the timer on screen
    //void UpdateTimer()
    //{
    //    //update the timer in the Canvas
    //    GameManager.instance.TimeRemaining -= Time.deltaTime;
    //    TimerImage.fillAmount = GameManager.instance.TimeRemaining / GameManager.instance.MaxTime;

    //    float displayTimeRemaining = Mathf.Floor(GameManager.instance.TimeRemaining);
    //    bottomText.text = "Time Remaining: " + displayTimeRemaining;
    //    bottomText.fontSize = 20;

    //    //if time runs out, declare game over.
    //    if (displayTimeRemaining <= 0 && GameManager.instance.bTimeRanOut == false)
    //    {

    //        Debug.Log("Time ran out.");
    //        GameManager.instance.bTimeRanOut = true;
    //        //GameManager.instance.LoseGame();

    //    }

    //}

    //update the score of the UI Manager score text
    void UpdateScoreText()
    {

        currentScore = GameManager.instance.score;

        scoreText.text = "Score: " + currentScore;

    }


    void UpdateLivesCount()
    {

        currentPlayerLives = GameManager.instance.playerLives;

        livesText.text = "Lives x " + currentPlayerLives;

    }


}
