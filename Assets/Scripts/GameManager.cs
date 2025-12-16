using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{

    //Singleton variable
    public static GameManager instance;

    [Header("Score")]
    public int score;

    [Header("Lives")]
    public int playerLives;
    public int resetLives;

    //variable to get the players transform for level loading
    public Transform layerEndLevelTransform;

    //variable to keep track of the player
    public PlayerPawn playerPawn;

    void Awake()
    {
        //check that there is only one instance of gameManager in this game.
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        GameObject.DontDestroyOnLoad(gameObject);

        

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //keeps tracks of the lives the player starts out with.
        resetLives = playerLives;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("GameManager PlayerPawn:" + playerPawn);

        if(playerLives <= 0)
        {
            Lose();
        }
    }

    private void Lose()
    {

        //TODO: increment score for persictant score
        if (score > PlayerPrefs.GetFloat("HighScore"))
        {

            //set current score to playerPrefs HighScore
            PlayerPrefs.SetFloat("HighScore", score);

        }

        //reset player lives
        playerLives = resetLives;

        //reset player score
        score = 0;

        //load Lose scene
        SceneManager.LoadScene("LoseScene");
      
    }

    public void Win()
    {

        //TODO: increment score for persictant score
        if (score > PlayerPrefs.GetFloat("HighScore"))
        {

            //set current score to playerPrefs HighScore
            PlayerPrefs.SetFloat("HighScore", score);

        }

        //reset player lives
        playerLives = resetLives;

        //reset player score
        score = 0;

    }
}
