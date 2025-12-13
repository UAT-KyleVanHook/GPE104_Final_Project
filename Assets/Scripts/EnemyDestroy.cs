using System.Security.Cryptography;
using UnityEngine;

public class EnemyDestroy : DeathComponent
{
    
    public int ScoreAmount;

    //destroy the gameObject this script is attached to.
    public override void Die()
    {
        //Increment score
        GameManager.instance.score += ScoreAmount;

        //destroy this object
        Destroy(gameObject);

    }
}
