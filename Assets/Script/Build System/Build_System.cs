using System.Collections.Generic;
using UnityEngine;

public class Build_System : MonoBehaviour
{
    public bool isBuilding;
    public bool haveItAHmmer;
    public int preview;

    public List<GameObject> AllPreview = new List<GameObject>();

    AlertManager alertManager;
    Inventory inventory;

    public allBuild[] _allBuilds;

    Vector2 mousePos;
    public Camera camera;

    private void Start()
    {
        alertManager = FindObjectOfType<AlertManager>().GetComponent<AlertManager>();
        inventory = FindObjectOfType<Inventory>().GetComponent<Inventory>();
        isBuilding = false;
        haveItAHmmer = false;
        preview = 0;

        for(int id = 0; id < _allBuilds.Length; id++)
        {
            AllPreview.Add(_allBuilds[id].preview);
            _allBuilds[id].preview.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (isBuilding)
            {
                isBuilding = false;
                DesactiveAllPreview();
            }else if (!isBuilding)
            {
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
                if (Inventory.ressource[0] <= _allBuilds[preview].ressource[0] && Inventory.ressource[1] <= _allBuilds[preview].ressource[1] && Inventory.ressource[2] <= _allBuilds[preview].ressource[2])
                {
                    GameObject _constrcut = Instantiate(_allBuilds[preview].after);
                    _constrcut.transform.position = new Vector2(mousePos.x, mousePos.y + 5);
                    DesactiveAllPreview();
                    isBuilding = false;
                    for (int i = 0; i < Inventory.ressource.Length; i++)
                    {
                        Inventory.ressource[i] -= _allBuilds[preview].ressource[i];
                    }
                }
                else
                {
                    alertManager.TextAlert(4f, "Erreur tu n'as pas les ressources");
                }
            }
        }
    }

    private void DesactiveAllPreview()
    {
        int length = AllPreview.Count;
        for(int i = 0; i < length; i++)
        {
            AllPreview[i].SetActive(false);
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