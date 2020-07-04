using System.Collections;
using UnityEngine;

public class ElectricityManager : MonoBehaviour
{
    public enum Type { cable, ElectricityGenerator};
    public Type type;

    public int MaxElectricity;
    public int currentElectricity;
    public int ElectricityCanGeneratePerSecond;
    public float waitTimesBeforeCanGenerateElectricity;

    public bool isItAElectricityGenerator;

    // Start is called before the first frame update
    void Start()
    {
        currentElectricity = 1;
        if(type == Type.ElectricityGenerator)
        {
            ElectricityGeneratorManagement();
            isItAElectricityGenerator = false;
        }else if(type == Type.cable)
        {
            isItAElectricityGenerator = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(currentElectricity > MaxElectricity)
        {
            currentElectricity = MaxElectricity;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Teste");
        if(collision.GetComponent<ElectricityManager>().isItAElectricityGenerator == true)
        {
            if(collision.GetComponent<ElectricityManager>().currentElectricity > 0)
            {
                currentElectricity++;
                collision.GetComponent<ElectricityManager>().currentElectricity--;
                StartCoroutine(CollectElectricity());
            }
            else if (collision.GetComponent<ElectricityManager>().currentElectricity < 0)
            {
                Debug.Log("No Electricity in " + collision.gameObject.name);
                StartCoroutine(CollectElectricity());
            }
        }
    }

    public void ElectricityGeneratorManagement()
    {
        StartCoroutine(GenerateElectricity());
    }

    private IEnumerator CollectElectricity()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);
        gameObject.SetActive(true);
    }

    private IEnumerator GenerateElectricity()
    {
        yield return new WaitForSeconds(waitTimesBeforeCanGenerateElectricity);
        currentElectricity += ElectricityCanGeneratePerSecond;
        ElectricityGeneratorManagement();
    }
}
