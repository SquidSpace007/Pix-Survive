using UnityEngine;

public class E_Active : MonoBehaviour
{
    public GameObject e;

    private void Start()
    {
        e.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            e.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        e.SetActive(false);
    }
}
