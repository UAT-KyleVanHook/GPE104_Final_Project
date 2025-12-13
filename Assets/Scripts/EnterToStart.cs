using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterToStart : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PressEnter();
    }

    public void PressEnter()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}
