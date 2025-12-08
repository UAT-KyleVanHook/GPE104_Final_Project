using UnityEngine;

public class DeathTest : MonoBehaviour
{
    public Pawn pawnToTest;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Pawn newPawn = pawnToTest.GetComponent<Pawn>();

        //test if the functions of the Death and Health componenets work

        if (Input.GetKeyDown(KeyCode.P))
        {
            pawnToTest.deathComp.Die();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            pawnToTest.healthComp.TakeDamage(1);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            pawnToTest.healthComp.Heal(1);
        }

    }
}
