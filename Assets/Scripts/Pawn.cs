using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    [Header("Components")]
    //public HealthComponent health;
    //public DeathComponent death;
    public Rigidbody2D rigidBody2d;
    public BoxCollider2D jumpCollider;

    [Header("Movement")]
    //pawn jump speed
    public float moveSpeed;
    //max speed for pawn
    public float maxSpeed;

    //pawn jump force
    public float jumpForce;
    
    //bool to detect if the pawn is jumping
    public bool bIsJumping;


    public abstract void MoveRight();
    public abstract void MoveLeft();
    public abstract void Jump();
}