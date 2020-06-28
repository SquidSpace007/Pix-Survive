using System.Collections;
using UnityEngine;

public class InventoryManagement : MonoBehaviour
{
    public GameObject inventoryUI;
    public GameObject basicConstructionPanelUI;
    public GameObject ElectiqueComponentPanel;
    public GameObject[] allUI;
    public GameObject backGrounds;

    public bool isInventoryActive;
    public bool canCloseInventory;

    public GameObject sword;
    public GameObject pick;
    public GameObject axe;
    public GameObject hammer;

    public PlayerMovement playerMovement;
    Build_System buildSystem;

    void Start()
    {
        backGrounds.SetActive(false);
        buildSystem = FindObjectOfType<Build_System>().GetComponent<Build_System>();
        basicConstructionPanelUI.SetActive(false);
        inventoryUI.SetActive(false);
        ElectiqueComponentPanel.SetActive(false);
        canCloseInventory = false;
        isInventoryActive = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if(isInventoryActive == false && canCloseInventory == false)
            {
                backGrounds.SetActive(true);
                foreach(var element in allUI)
                {
                    element.SetActive(false);
                }
                Cursor.visible = true;
                isInventoryActive = true;
                inventoryUI.SetActive(true);
                StartCoroutine(WaitBeforeCanCloseInventory());
            }

            if (isInventoryActive == true && canCloseInventory == true)
            {
                backGrounds.SetActive(false);
                foreach (var element in allUI)
                {
                    element.SetActive(true);
                }
                Cursor.visible = false;
                isInventoryActive = false;
                basicConstructionPanelUI.SetActive(false);
                inventoryUI.SetActive(false);
                ElectiqueComponentPanel.SetActive(false);
                StartCoroutine(WaitBeforeCanOpenInventory());
            }
        }

        VerifieComponent();
    }

    void VerifieComponent()
    {
        if(playerMovement.haveItAAxe == false)
        {
            axe.SetActive(false);
        }else if(playerMovement.haveItAAxe == true)
        {
            axe.SetActive(true);
        }

        if (playerMovement.haveItAPick == false)
        {
            pick.SetActive(false);
        }
        else if (playerMovement.haveItAPick == true)
        {
            pick.SetActive(true);
        }

        if (playerMovement.haveItASword == false)
        {
            sword.SetActive(false);
        }
        else if (playerMovement.haveItASword == true)
        {
            sword.SetActive(true);
        }

        if (buildSystem.haveItAHmmer == false)
        {
            hammer.SetActive(false);
        }
        else if (buildSystem.haveItAHmmer == true)
        {
            hammer.SetActive(true);
        }
    }

    public void CloseButton()
    {
        backGrounds.SetActive(false);
        foreach (var element in allUI)
        {
            element.SetActive(true);
        }
        Cursor.visible = false;
        isInventoryActive = false;
        basicConstructionPanelUI.SetActive(false);
        inventoryUI.SetActive(false);
        ElectiqueComponentPanel.SetActive(false);
        StartCoroutine(WaitBeforeCanOpenInventory());
    }

    public IEnumerator WaitBeforeCanCloseInventory()
    {
        yield return new WaitForSeconds(2f);
        canCloseInventory = true;
    }

    public IEnumerator WaitBeforeCanOpenInventory()
    {
        yield return new WaitForSeconds(1f);
        canCloseInventory = false;
    }
}
