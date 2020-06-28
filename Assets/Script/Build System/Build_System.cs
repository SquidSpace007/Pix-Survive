using UnityEngine;

public class Build_System : MonoBehaviour
{
    public int preview;
    public bool haveItAHmmer;
    public bool isBuilding;

    public GameObject[] allPreview;
    public GameObject buildInterface;

    public Ressource[] ressource;

    Inventory inventory;
    AlertManager alert;
    UiBuildSystem uiBuild;

    public Vector2 mousePos;
    public float mouseWheel;
    public Camera mainCamera;

    public void Start()
    {
        buildInterface.SetActive(false);
        preview = 0;
        haveItAHmmer = true;
        isBuilding = false;
        for(int i = 0; i < allPreview.Length; i++)
        {
            allPreview[i].SetActive(false);
        }
        uiBuild = FindObjectOfType<UiBuildSystem>().GetComponent<UiBuildSystem>();
        inventory = FindObjectOfType<Inventory>().GetComponent<Inventory>();
        alert = FindObjectOfType<AlertManager>().GetComponent<AlertManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (isBuilding)
            {
                uiBuild.allCate[0].SetActive(false);
                buildInterface.SetActive(false);
                DesactiveAllRessource();
                isBuilding = false;
            }else if(!isBuilding && haveItAHmmer == true)
            {
                uiBuild.allCate[0].SetActive(true);
                buildInterface.SetActive(true);
            }
        }

        if (isBuilding)
        {
            ressource[preview].preview.SetActive(true);
            ressource[preview].preview.transform.position = new Vector2(Mathf.Round(mainCamera.ScreenToWorldPoint(Input.mousePosition).x), Mathf.Round(mainCamera.ScreenToWorldPoint(Input.mousePosition).y + 5));

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if(Inventory.ressource[0] >= ressource[preview]._ressource[0] && Inventory.ressource[1] >= ressource[preview]._ressource[1] && Inventory.ressource[2] >= ressource[preview]._ressource[2] && Inventory.ressource[3] >= ressource[preview]._ressource[3] && Inventory.ressource[4] >= ressource[preview]._ressource[4] && Inventory.ressource[5] >= ressource[preview]._ressource[5] && Inventory.ressource[6] >= ressource[preview]._ressource[6] && Inventory.ressource[7] >= ressource[preview]._ressource[7] && Inventory.ressource[8] >= ressource[preview]._ressource[8] && Inventory.ressource[9] >= ressource[preview]._ressource[9] && Inventory.ressource[10] >= ressource[preview]._ressource[10] && Inventory.ressource[11] >= ressource[preview]._ressource[11] && Inventory.ressource[12] >= ressource[preview]._ressource[12] && Inventory.ressource[13] >= ressource[preview]._ressource[13] && Inventory.ressource[14] >= ressource[preview]._ressource[14])
                {
                    GameObject _ressource = Instantiate(ressource[preview].after);
                    _ressource.transform.position = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y + 5));
                    isBuilding = false;
                    DesactiveAllRessource();
                    for(int id = 0; id < Inventory.ressource.Length; id++)
                    {
                        Inventory.ressource[id] -= ressource[preview]._ressource[id];
                    }
                }
                else
                {
                    alert.TextAlert(3, "Erreur tu n'as pas les ressource");
                    Debug.Log("Tu n'as pas les ressource");
                }
            }
        }
    }

    void DesactiveAllRessource()
    {
        foreach(var element in allPreview)
        {
            element.SetActive(false);
        }
    }

    [System.Serializable]
    public struct Ressource
    {
        public string name;
        public GameObject after;
        public GameObject preview;

        public int[] _ressource;
    }
}
