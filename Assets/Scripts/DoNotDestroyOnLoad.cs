using UnityEngine;

public class DoNotDestroyOnLoad : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        //Do not destroy the gameObject that this script is attached to 
        GameObject.DontDestroyOnLoad(this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
