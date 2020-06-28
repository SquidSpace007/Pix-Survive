using UnityEngine;

public class Security : MonoBehaviour
{
    SystemGeneration systemGeneration;

    // Start is called before the first frame update
    void Start()
    {
        systemGeneration = FindObjectOfType<SystemGeneration>().GetComponent<SystemGeneration>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject col = collision.gameObject;
        if(col.GetComponent<Collectable>().isThatARessource == true && !col.CompareTag("Player"))
        {
            int randomX = Random.Range(0, 100);
            int randomY = Random.Range(0, 140);
            col.transform.position = new Vector2(randomX, randomY);
            Debug.Log("new Pos for GameObject");
        }
    }
}
