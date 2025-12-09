using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //Singleton variable
    public static GameManager instance;

    [Header("Score")]
    public int score;

    [Header("Lives")]
    public int playerLives;



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

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        //Make sure that tihs object is not destroyed on a scen load
        GameObject.DontDestroyOnLoad(this.gameObject);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
