using UnityEngine;

public class DestroyLock : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //check if all of the keys in the level that the keyList is in, are destroyed.
        //if true destroy this object.
        if(LockKeyList.instance.keyList.Count == 0)
        {
            Destroy(gameObject);
        }
        
    }
}
