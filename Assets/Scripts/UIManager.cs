using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;


    [Header("Score")]
    public TMP_Text scoreText;
    int currentScore;

    [Header("Lives")]
    public TMP_Text livesText;
    int currentPlayerLives;

    [Header("Health")]
    public TMP_Text healthText;
    public Slider healthBarSlider;
    public int currentHealth;
    public int maxHealth;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //check that there is not another instance of UIManager currently in the level. 
        //If we don't have a PlayerInstance, set this instance as the current instance. Otherwise, destroy the other instance.
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //don't destroy object on scene load
        GameObject.DontDestroyOnLoad(gameObject);


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

        UpdateHealth();

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


    //update the values and slider of the healthbar on the UI
    void UpdateHealth()
    {

        //update healthbar slider, getting box its current health and max health
        healthBarSlider.value = currentHealth;
        healthBarSlider.maxValue = maxHealth;

        //set the text to the current value
        healthText.text = currentHealth.ToString() + "/" + maxHealth.ToString();


    }



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
