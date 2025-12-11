using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{

    //Singleton variable
    public static GameManager instance;

    [Header("Score")]
    public int score;

    [Header("Lives")]
    public int playerLives;

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


    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("GameManager PlayerPawn:" + playerPawn);
    }
}
