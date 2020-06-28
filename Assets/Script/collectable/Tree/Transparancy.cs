using UnityEngine;

public class Transparancy : MonoBehaviour
{
    public SpriteRenderer spriteRendererTree;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spriteRendererTree.color = new Color(1f, 1f, 1f, 0.70f); 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRendererTree.color = new Color(1f, 1f, 1f, 1f);
    }
}
