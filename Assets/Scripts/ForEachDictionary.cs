using System.Collections.Generic;
using UnityEngine;

public class ForEachDictionary : MonoBehaviour
{
    //make a dictionary
    Dictionary<string, int> peopleAges = new Dictionary<string, int>();
    public bool playLoop;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //add all the items to the dictionary
        peopleAges.Add("Tom", 50);
        peopleAges.Add("Mary", 38);
        peopleAges.Add("Bob", 42);
        peopleAges.Add("Chris", 16);
        peopleAges.Add("Jack", 21);

        playLoop = true;

    }

    // Update is called once per frame
    void Update()
    {
        //If the bool playLoop is true, start the PrintAges method
        if (playLoop)
        {
            PrintAges();
        }

        
    }

   private void PrintAges()
    {

        foreach(KeyValuePair<string, int> age in peopleAges)
        {

            Debug.Log(age.Key + " age is " + age.Value + ".");

        }


        playLoop = false;

    }
}
