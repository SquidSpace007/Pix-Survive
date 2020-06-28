using UnityEngine;

public class UiBuildSystem : MonoBehaviour
{
    Build_System build_system;
    public GameObject obj;

    private void Start()
    {
        build_system = FindObjectOfType<Build_System>().GetComponent<Build_System>();
    }

    public void StartBuildSystem(int buildID)
    {
            obj.SetActive(false);
            build_system.isBuilding = true;
            build_system.preview = buildID;
    }
}
