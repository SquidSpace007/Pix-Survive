using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtabliActive : MonoBehaviour
{
    public bool wantItToBeActive;
    public bool isItActive;

    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        isItActive = false;
        wantItToBeActive = false;
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isItActive == true)
        {
            Cursor.visible = true;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isItActive = false;
                Cursor.visible = false;
                panel.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(ActiveOrDesactive());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && wantItToBeActive == true)
        {
            isItActive = true;
            panel.SetActive(true);
            wantItToBeActive = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isItActive = false;
        panel.SetActive(false);
    }

    public IEnumerator ActiveOrDesactive()
    {
        wantItToBeActive = true;
        gameObject.SetActive(false);
        gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        wantItToBeActive = false;
    }
}
