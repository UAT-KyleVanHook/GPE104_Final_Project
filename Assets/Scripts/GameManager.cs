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

        //keeps tracks of the lives the player starts out with.
        resetLives = playerLives;

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("GameManager PlayerPawn:" + playerPawn);

        if(playerLives == 0)
        {
            Lose();
        }
    }

    private void Lose()
    {

        //TODO: increment score for persictant score


        ////destroy all instace objects so they don't appear in the next scene
        //Destroy(UIManager.instance.gameObject);
        //Destroy(PlayerPawn.playerInstance.gameObject);
        //Destroy(PlayerController.instance.gameObject);
        //Destroy(CamFollowPlayer.instance.gameObject);
        //Destroy(PlayerPawn.playerInstance.gameObject);

        playerLives = resetLives;

        //load Lose scene
        SceneManager.LoadScene("LoseScene");
      
    }
}
