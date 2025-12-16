using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //if the collision with this object is the player, delete all DontDestroyOnLoad items and transition to the win scene
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {

            //double check that this is a player
            PlayerPawn tempPawn = collision.GetComponent<PlayerPawn>();

            if (tempPawn != null)
            {
                //go to the game manager and set the highscor to player prefs, reset lives, and reset score.
                GameManager.instance.Win();

                //load win scene
                SceneManager.LoadScene("WinScene");


            }

        }


    }
}
