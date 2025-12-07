using UnityEngine;

public abstract class Controller : MonoBehaviour
{

    public Pawn pawn;

    //method where the pawn will make decisions with input
    public abstract void MakeDecisions();

}
