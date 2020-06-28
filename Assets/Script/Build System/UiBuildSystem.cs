using UnityEngine;

public class UiBuildSystem : MonoBehaviour
{
    Build_System build_system;
    public GameObject obj;
    public GameObject[] allCate;

    private void Start()
    {
        foreach(var element in allCate)
        {
            element.SetActive(false);
        }
        build_system = FindObjectOfType<Build_System>().GetComponent<Build_System>();
    }

    public void StartBuildSystem(int buildID)
    {
            obj.SetActive(false);
            build_system.isBuilding = true;
            build_system.preview = buildID;
    }

    public void Open(GameObject pannel)
    {
        for(int i = 0; i < allCate.Length; i++)
        {
            allCate[i].SetActive(false);
            pannel.SetActive(true);
        }
    }
}
