using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ElectricityManager : MonoBehaviour
{
    public int MaxElectricity;
    int minElectricity = 0;
    public int currentElectricity;

    public Text text;
    public int MaxElectricityCanGenerate;
    public int ElecricityCanGeneratePerSecond;
    public float frequencyElectricityCanGeneratePerSecond;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.CompareTag("ElectricitySource"))
        {
            gameObject.SetActive(false);
            gameObject.SetActive(true);
        }
        if(gameObject.CompareTag("Electricity Generator"))
        {
            AddElectricityManager();
        }
        currentElectricity = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.CompareTag("Electricity Generator"))
        {
            text.text = currentElectricity.ToString() + "/" + MaxElectricity.ToString();
        }

        if(currentElectricity > MaxElectricity)
        {
            currentElectricity = MaxElectricity;
        }

        if(currentElectricity < minElectricity)
        {
            currentElectricity = minElectricity;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        print("Hello World");
        if (collision.CompareTag("Electricity Source") || collision.CompareTag("Electricity Generator") && gameObject.CompareTag("Electricity Source") && collision.GetComponent<ElectricityManager>().currentElectricity > 0)
        {
            collision.GetComponent<ElectricityManager>().currentElectricity--;
            currentElectricity++;
            gameObject.SetActive(false);
            gameObject.SetActive(true);        
        }
    }

    public void AddElectricityManager()
    {
        StartCoroutine(AddElectricty(frequencyElectricityCanGeneratePerSecond, ElecricityCanGeneratePerSecond));
    }

    public IEnumerator AddElectricty(float frequency, int amount)
    {
        currentElectricity += amount;
        yield return new WaitForSeconds(frequency);
        AddElectricityManager();
    }
}
