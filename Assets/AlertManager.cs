using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class AlertManager : MonoBehaviour
{
    [Header("Alert By Text")]
    public Text text;

    [Space]

    [Header("Alert By Box")]
    public GameObject alertBox;
    public Image alertBoxImg;
    public TextMeshProUGUI alertBoxTitle;
    public TextMeshProUGUI alertBoxDesc;

    void Start()
    {
        Debug.Log("Started");
    }

    public void NotificationAlertManager(Image img, string Title, string Desc, int times)
    {
        StartCoroutine(NotificationAlert(img, Title, Desc, times));
    }

    public IEnumerator NotificationAlert(Image _img, string _Title, string _Desc, int _Times)
    {
        alertBox.SetActive(true);
        alertBoxImg.GetComponent<Image>().sprite = _img.GetComponent<Image>().sprite;
        alertBoxTitle.SetText(_Title.ToString());
        alertBoxDesc.SetText(_Desc.ToString());
        yield return new WaitForSeconds(_Times);
        alertBox.SetActive(false);
    }

    public void TextAlertManager(float times, string content)
    {
        StartCoroutine(TextAlert(times, content));
    }

    public IEnumerator TextAlert(float times, string textContent)
    {
        text.text = textContent;
        yield return new WaitForSeconds(times);
        text.text = "";
    }
}
