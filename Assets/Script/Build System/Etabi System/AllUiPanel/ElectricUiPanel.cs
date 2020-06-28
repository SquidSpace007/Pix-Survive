using UnityEngine;

public class ElectricUiPanel : MonoBehaviour
{
    Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<Inventory>().GetComponent<Inventory>();
    }
    
    public void CraftProcess()
    {
        CraftObjects(8, 1, 0, 0, 0, 0, 0, 8, 7, 0, 0, 5, 0, 0, 0, 0, 2);
    }
    public void CraftPrintedCircuit()
    {
        CraftObjects(11, 1, 0, 0, 0, 0, 0, 0, 3, 0, 0, 7, 0, 0, 1, 0, 1);
    }
    public void CraftMinProcessor()
    {
        CraftObjects(9, 4, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0);
    }
    public void CalculatingUnit()
    {
        CraftObjects(12, 1, 0, 0, 0, 0, 0, 4, 7, 0, 0, 15, 0, 0, 0, 0, 0);
    }
    public void CraftGreenCard()
    {
        CraftObjects(14, 1, 0, 0, 0, 0, 0, 2, 3, 0, 0, 0, 0, 0, 0, 0, 0);
    }
    public void craftRam()
    {
        CraftObjects(10, 1, 0, 0, 0, 0, 0, 2, 3, 0, 0, 9, 0, 0, 4, 0, 1);
    }

    void CraftObjects(int ressourceId, int amount, int nbBois, int nbPierre, int nbFood, int nbWater, int coal, int iron, int copper, int gold, int processor, int mini_processor, int ram, int printed_circuit, int calculating_unit, int socket, int green_card)
    {
        if(Inventory.ressource[1] >= nbPierre && Inventory.ressource[2] >= nbFood && Inventory.ressource[3] >= nbWater && Inventory.ressource[0] >= nbBois && Inventory.ressource[4] >= coal && Inventory.ressource[5] >= iron && Inventory.ressource[6] >= copper && Inventory.ressource[7] >= gold && Inventory.ressource[8] >= processor && Inventory.ressource[9] >= mini_processor && Inventory.ressource[10] >= ram && Inventory.ressource[11] >= printed_circuit && Inventory.ressource[12] >= calculating_unit && Inventory.ressource[13] >= socket && Inventory.ressource[14] >= green_card)
        {
            Inventory.AddRessource(ressourceId, amount);
            Inventory.RemoveRessource(nbBois, nbPierre, nbFood, nbWater, coal, iron, copper, gold, processor, mini_processor, ram, printed_circuit, calculating_unit, socket, green_card);
        }
        else
        {
            Debug.Log("Tu n'as pas les ressource nécéssaire");
        }
    }
}
