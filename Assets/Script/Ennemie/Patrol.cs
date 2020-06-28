using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;
    public float movement;

    public SpriteRenderer graphics;

    public Transform[] moveSpots;
    private int randomSpot;

    public Animator anim;


    void Start()
    {
        movement = 0;
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        movement = 1;

        if(Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            graphics.flipX = !graphics.flipX;
            if(waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                movement = 0;
                waitTime = startWaitTime;
            }
            else
            {
                randomSpot = Random.Range(0, moveSpots.Length);
            }
        }
    }
}
