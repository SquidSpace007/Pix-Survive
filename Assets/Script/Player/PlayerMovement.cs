using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    int playerId;

    public float moveSpeed;

    public Rigidbody2D rb;
    public Animator animator;

    public GameObject Axecollider;
    public GameObject PickCollider;
    public GameObject SwordCollider;

    public GameObject canvas;

    private Inventory inventory;
    private AlertManager alert;

    public bool isDigging;
    public bool isEquiped;
    private bool canDesequip;
    public bool isPick;
    public bool isPickEquip;
    public bool isSword;
    public bool isSwordEquip;

    public bool haveItAAxe;
    public bool haveItAPick;
    public bool haveItASword;

    Vector2 movement;

    private void Start()
    {
        alert = FindObjectOfType<AlertManager>().GetComponent<AlertManager>();
        inventory = FindObjectOfType<Inventory>().GetComponent<Inventory>();
        haveItAAxe = false;
        haveItAPick = false;
        haveItASword = false;
        canvas.SetActive(true);
        gameObject.transform.position = GameObject.FindGameObjectWithTag("PlayerSpawn").transform.position;
        Cursor.visible = true;
        Axecollider.SetActive(false);
        SwordCollider.SetActive(false);
        canDesequip = false;
        PickCollider.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetBool("isSword", isSword);
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        ActiveTools();

        if (Input.GetKeyDown(KeyCode.F1))
        {
            SavePlayer();
        }else if (Input.GetKeyDown(KeyCode.F2))
        {
            LoadPlayer();
        }
    }

    void ActiveTools()
    {
        animator.SetBool("isEquiped", isEquiped);
        animator.SetBool("isDigging", isDigging);
        animator.SetBool("isPick", isPick);
        animator.SetBool("isPickEquip", isPickEquip);
        animator.SetBool("isSwordEquip", isSwordEquip);

        if (Input.GetKeyDown(KeyCode.C))
        {
            if(isEquiped == false && canDesequip == false && isPickEquip == false && isSwordEquip == false && haveItAAxe == true)
            {
                StartCoroutine(Axe());
            }
            else
            {
                alert.TextAlertManager(3f, "Tu n'as pas de hache");
            }
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            if(isPickEquip == false && canDesequip == false && isEquiped == false && isSwordEquip == false && haveItAPick == true)
            {
                StartCoroutine(Pick());
            }
            else
            {
                alert.TextAlertManager(3f, "Tu n'as pas de pioche");
            }
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            if (isSwordEquip == false && canDesequip == false && isEquiped == false && isPickEquip == false && haveItASword == true)
            {
                StartCoroutine(Sword());
            }
            else
            {
                alert.TextAlertManager(3f, "Tu n'as pas d'épée");
            }
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    IEnumerator Axe()
    {
        isEquiped = true;
        isDigging = true;
        Axecollider.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        isEquiped = false;
        isDigging = false;
        Axecollider.SetActive(false);
    }


    IEnumerator Pick()
    {
        isPick = true;
        isPickEquip = true;
        PickCollider.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        isPick = false;
        isPickEquip = false;
        PickCollider.SetActive(false);
    }


    IEnumerator Sword()
    {
        isSword = true;
        isSwordEquip = true;
        SwordCollider.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        isSword = false;
        isSwordEquip = false;
        SwordCollider.SetActive(false);
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this, gameObject);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        Vector3 _position;
        _position.x = data.position[0];
        _position.y = data.position[1];
        _position.z = data.position[2];
        gameObject.transform.position = _position;
    }
}


