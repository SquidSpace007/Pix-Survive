using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damageOnCollision = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerHealth.TakeDamage(damageOnCollision);
        }
    }
}
