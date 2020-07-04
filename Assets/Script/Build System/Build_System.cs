using System.Collections.Generic;
using UnityEngine;

public class Build_System : MonoBehaviour
{
    public bool isBuilding;
    public bool haveItAHmmer;
    public bool isPannel;
    
    public int preview;

    AlertManager alertManager;
    Inventory inventory;

    public allBuild[] _allBuilds;

    Vector2 mousePos;
    public Camera camera;

    public GameObject Panel;
    public GameObject Cate;

    private void Start()
    {
        isPannel = false;
        Cate.SetActive(false);
        Panel.SetActive(false);
        alertManager = FindObjectOfType<AlertManager>().GetComponent<AlertManager>();
        inventory = FindObjectOfType<Inventory>().GetComponent<Inventory>();
        isBuilding = false;
        haveItAHmmer = false;
        preview = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (isBuilding)
            {
                Cate.SetActive(false);
                Panel.SetActive(false);
                DesactiveAllPreview();
                isBuilding = false;
            }else if (!isBuilding)
            {
                Cate.SetActive(true);
                Panel.SetActive(true);
                DesactiveAllPreview();
                isBuilding = true;
            }
        }

        if (isBuilding)
        {
            mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
            _allBuilds[preview].preview.SetActive(true);
            _allBuilds[preview].preview.transform.position = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y + 5));

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (Inventory.ressource[0] >= _allBuilds[preview].ressource[0] && Inventory.ressource[1] >= _allBuilds[preview].ressource[1] && Inventory.ressource[2] >= _allBuilds[preview].ressource[2] && Inventory.ressource[3] >= _allBuilds[preview].ressource[3] && Inventory.ressource[4] >= _allBuilds[preview].ressource[4] && Inventory.ressource[5] >= _allBuilds[preview].ressource[5] && Inventory.ressource[6] >= _allBuilds[preview].ressource[6] && Inventory.ressource[7] >= _allBuilds[preview].ressource[7] && Inventory.ressource[8] >= _allBuilds[preview].ressource[8] && Inventory.ressource[9] >= _allBuilds[preview].ressource[9] && Inventory.ressource[10] >= _allBuilds[preview].ressource[10] && Inventory.ressource[11] >= _allBuilds[preview].ressource[11] && Inventory.ressource[12] >= _allBuilds[preview].ressource[12] && Inventory.ressource[13] >= _allBuilds[preview].ressource[13] && Inventory.ressource[14] >= _allBuilds[preview].ressource[14])
                {
                    GameObject _constrcut = Instantiate(_allBuilds[preview].after);
                    _constrcut.transform.position = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y + 5));
                    Debug.Log("Suppr Ressource");
                    for (int i = 0; i < Inventory.ressource.Length - 1; i++)
                    {
                        Inventory.ressource[i] -= _allBuilds[preview].ressource[i];
                    }
                    isBuilding = false;
                }
                else
                {
                    Debug.Log("Tu n'as pas les ressources");
                    alertManager.TextAlert(4f, "Erreur tu n'as pas les ressources");
                }
            }
        }
    }

    private void DesactiveAllPreview()
    {
        for (int i = 0; i < _allBuilds.Length - 1; i++)
        {
            _allBuilds[i].preview.SetActive(false);
        }
    }

    [System.Serializable]
    public struct allBuild
    {
        public string name;

        public GameObject preview;
        public GameObject after;

        public int[] ressource;
    }

}