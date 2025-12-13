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

                //destroy all instace objects so they don't appear in the next scene
                //Destroy(UIManager.instance.gameObject);
                //Destroy(GameManager.instance.gameObject);
                //Destroy(PlayerPawn.playerInstance.gameObject);
                //Destroy(PlayerController.instance.gameObject);
                //Destroy(CamFollowPlayer.instance.gameObject);

                GameManager.instance.playerLives = GameManager.instance.resetLives;
                //load win scene
                SceneManager.LoadScene("WinScene");


            }

        }


    }
}
