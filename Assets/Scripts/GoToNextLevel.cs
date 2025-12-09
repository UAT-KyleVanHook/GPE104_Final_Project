using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour
{

    public string nextLevel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //On Collision with the tigger box
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the collided object has the tap "Player", then load the next scene in nextLevel.
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
}
