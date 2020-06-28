using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Inventory : MonoBehaviour
{

    [SerializeField]
    public static int[] ressource = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
    public TextMeshProUGUI[] ressourceText;
    public string[] ressourceName = { "wood", "rock", "rations", "water", "coal", "iron", "copper", "gold", "Processor", "mini processor", "Ram", "Printed circuit board", "calculating unit", "socket" };
    int coal = 0;

    // Food Bar
    public PlayerFood playerFood;
    public FoodBar foodBar;

    //Water Bar
    public PlayerWater playerWater;
    public WaterBar waterBar;

    //Adding System
    public AddingSystem addingSystem;

    public bool canEat;

    public Text errorText;

    public string addingSystemString;

    //sur quelle ressource / text est t'on
    int currentTextOrRessource;

    // Start is called before the first frame update
    void Start()
    {
        currentTextOrRessource = 0;
        for(int ressource_id = 0; ressource_id == ressource.Length; ressource_id++)
        {
            ressource[ressource_id] = 0;
            ressourceText[ressource_id].SetText(ressource[ressource_id].ToString() + " " + ressourceName[ressource_id]); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTextOrRessource == ressourceText.Length)
        {
            currentTextOrRessource = 0;
        }
        ressourceText[currentTextOrRessource].text = ressource[currentTextOrRessource].ToString() + " " + ressourceName[currentTextOrRessource];
        currentTextOrRessource++;

        if (Input.GetKeyDown(KeyCode.F))
        {
            for(int i = 0; i <= ressource.Length - 1; i++)
            {
                ressource[i]++;
            }
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            ressource[0]--;
        }

        if (ressource[3] < 0)
        {
            ressource[3] = 0;
        }

        if (ressource[2] < 0)
        {
            ressource[2] = 0;
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (ressource[3] == 0)
            {
                errorText.text = "Erreur tu n'as pas d'eau";
                StartCoroutine(DesText());
            }

            if (ressource[3] == 1)
            {
                addingSystemString = "+ 20 point d'eau";
                addingSystem.AddingTextChange(addingSystemString);
                playerWater.currentWater += 20;
                ressource[3] -= 1;
                waterBar.SetHealth(playerWater.currentWater);
                print(playerWater.currentWater);
                print(ressource[3]);
            }

            if (ressource[3] > 1)
            {
                addingSystemString = "+ 20 point d'eau";
                addingSystem.AddingTextChange(addingSystemString);
                playerWater.currentWater += 20;
                ressource[3] -= 1;
                waterBar.SetHealth(playerWater.currentWater);
                print(playerWater.currentWater);
                print(ressource[3]);
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (ressource[2] == 0)
            {
                errorText.text = "Erreur tu n'as pas de nouriture";
                StartCoroutine(DesText());
            }

            if (ressource[2] > 1 && canEat == true)
            {
                addingSystemString = "+ 20 de nourriture";
                addingSystem.AddingTextChange(addingSystemString);
                playerFood.currentFood += 20;
                ressource[2] -= 1;
                foodBar.SetFood(playerFood.currentFood);
                print(playerFood.currentFood);
                print(ressource[2]);
            }

            if (ressource[2] == 1 && canEat == true)
            {
                addingSystemString = "+ 20 de nourriture";
                addingSystem.AddingTextChange(addingSystemString);
                playerFood.currentFood += 20;
                ressource[2] -= 1;
                foodBar.SetFood(playerFood.currentFood);
                print(playerFood.currentFood);
                print(ressource[2]);
            }
        }
    }

    public static void AddRessource(int ressourceIndex, int nb)
    {
        ressource[ressourceIndex] += nb;
    }

    public static void RemoveRessource(int nbWoods, int nbRocks, int nbFoods, int nbWaters, int nbCoals, int nbIrons, int nbCuivres, int nbOrs, int processor, int minprocessor, int ram, int printed_card, int calculating_unity, int socket, int green_card)
    {
        ressource[0] -= nbWoods;
        ressource[1] -= nbRocks;
        ressource[2] -= nbFoods;
        ressource[3] -= nbWaters;
        ressource[4] -= nbCoals;
        ressource[5] -= nbIrons;
        ressource[6] -= nbCuivres;
        ressource[7] -= nbOrs;
        ressource[8] -= processor;
        ressource[9] -= minprocessor;
        ressource[10] -= ram;
        ressource[11] -= printed_card;
        ressource[12] -= calculating_unity;
        ressource[13] -= socket;
        ressource[14] -= green_card;
    }

    public IEnumerator CanEat()
    {
        canEat = false;
        yield return new WaitForSeconds(0.9f);
        canEat = true;
    }

    public IEnumerator DesText()
    {
        yield return new WaitForSeconds(3f);
        errorText.text = "";
    }
}
