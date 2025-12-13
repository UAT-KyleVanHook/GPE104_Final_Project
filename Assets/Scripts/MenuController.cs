using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    //On start, go to the gameplayscene.
    public void OnStartClick()
    {

        SceneManager.LoadScene("Level_1");

    }

    public void OnMenuClick()
    {

        SceneManager.LoadScene("MenuScene");

    }

    public void OnCreditsClick()
    {

        SceneManager.LoadScene("CreditsScene");

    }

    public void OnResetScoreClick()
    {

        //set the HighScore in PlayerPrefs to zero
        PlayerPrefs.SetFloat("HighScore", 0.0f);

    }

    //when exit button is clicked, exit out of game.
    public void OnExitClick()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        Application.Quit();

    }
}
