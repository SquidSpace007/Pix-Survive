using TMPro;
using UnityEngine;

public class ToolsManagement : MonoBehaviour
{
    Build_System buildSystem;
    PlayerMovement playerMovement;

    public TextMeshProUGUI[] text;
    public int[] durability;
    public int[] maxDurability;

    public int currentPreview;

    // Start is called before the first frame update
    void Start()
    {
        buildSystem = FindObjectOfType<Build_System>().GetComponent<Build_System>();
        playerMovement = FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>();

        for(int i = 0; i < maxDurability.Length; i++)
        {
            maxDurability[i] = 50;
            durability[i] = maxDurability[i];
            text[i].SetText(durability[i].ToString() + "/" + maxDurability[i].ToString());
        }

        currentPreview = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPreview < durability.Length - 1)
        {
            currentPreview = 0;
        }

        currentPreview++;
        text[currentPreview].SetText(durability[currentPreview].ToString() + "/" + maxDurability[currentPreview].ToString());
    }
}
