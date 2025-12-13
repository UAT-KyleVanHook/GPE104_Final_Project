using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class LockKeyList : MonoBehaviour
{

    public static LockKeyList instance;

    public List<DestroyKey> keyList;

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

        //make a new list
        keyList = new List<DestroyKey>();

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("Keys in level: " + keyList.Count);
        
    }
}
