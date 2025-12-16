using TMPro;
using UnityEngine;

public class HighcoreUI : MonoBehaviour
{
    public TMP_Text highScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HighScoreUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        HighScoreUpdate();
    }

    public void HighScoreUpdate()
    {

        //get the HighScore and assign to text
        highScoreText.text = "HighScore: " + PlayerPrefs.GetFloat("HighScore").ToString();



    }
}
