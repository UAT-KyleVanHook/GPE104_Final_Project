using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    [Header("Components")]
    public HealthComponent healthComp;
    public DeathComponent deathComp;
    public Rigidbody2D rigidBody2d;
    public BoxCollider2D jumpCollider;
    public SpriteRenderer spriteRenderer;

    [Header("Movement")]
    //pawn jump speed
    public float moveSpeed;
    //max speed for pawn
    public float maxSpeed;

    //pawn jump force
    public float jumpForce;
    


    public abstract void MoveRight();
    public abstract void MoveLeft();
    public abstract void Jump();
}