using UnityEngine;

public abstract class HealthComponent : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public abstract void TakeDamage(int amount);

    public abstract bool isAlive();

    public abstract void Heal(int amount);
    public abstract void Die();
}
