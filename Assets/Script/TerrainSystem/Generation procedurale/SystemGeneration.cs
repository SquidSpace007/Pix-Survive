using UnityEngine;

public class SystemGeneration : MonoBehaviour
{
    public int width;
    public int height;

    public GameObject parentObject;
    public Transform parentObjectTransform;

    public generationObjectManagement[] _generationObjectManagements;
    
    void Start()
    {
        StartGeneration(false);
    }

    void StartGeneration(bool want)
    {
        if(want == false)
        {
            GameObject parent = Instantiate(parentObject);
            Transform parentObjectTransform = parent.transform;
            GenerateObjectId(parent, parentObjectTransform);
        } 
    }

    void GenerateObjectId(GameObject parents, Transform _parents)
    {
        for(int id = 0; id <= _generationObjectManagements.Length - 1; id++)
        {
            GenerateObjets(id, parents, _parents);
        }
    }

    void GenerateObjets(int id, GameObject parents, Transform _parents)
    {
        for(int x = Random.Range(-100, -90); x < width; x += Random.Range(Random.Range(_generationObjectManagements[id].MinX, _generationObjectManagements[id].MaxX), Random.Range(_generationObjectManagements[id].MinX, _generationObjectManagements[id].MaxX)))
        {
            for(int y = Random.Range(-100, -90); y < height; y += Random.Range(Random.Range(_generationObjectManagements[id].MinY, _generationObjectManagements[id].MaxY), Random.Range(_generationObjectManagements[id].MinY, _generationObjectManagements[id].MaxY)))
            {
                GameObject generateObject = Instantiate(_generationObjectManagements[id].objectToGenerate);
                generateObject.transform.position = new Vector2(x, y);
                generateObject.transform.parent = parentObjectTransform.transform;
            }
        }
    }
}

[System.Serializable]
public struct generationObjectManagement
{
    public string ressourceName;

    public GameObject objectToGenerate;

    public int MinX;
    public int MaxX;

    public int MinY;
    public int MaxY;
}
