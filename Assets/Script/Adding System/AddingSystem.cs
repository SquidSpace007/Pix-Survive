using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AddingSystem : MonoBehaviour
{
    public Text AddingText;

    // Start is called before the first frame update
    void Start()
    {
        AddingText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddingTextChange(string change)
    {
        AddingText.text = change;
        StartCoroutine(CloseChange(3f));
    }

    public IEnumerator CloseChange(float Times)
    {
        yield return new WaitForSeconds(Times);
        AddingText.text = "";
    }
}
