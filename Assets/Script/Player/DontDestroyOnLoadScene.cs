using UnityEngine;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    public GameObject[] dontDestroyOnLoadScene;

    // Update is called once per frame
    void Update()
    {
        foreach(var elements in dontDestroyOnLoadScene)
        {
            DontDestroyOnLoad(elements);
        }
    }
}
