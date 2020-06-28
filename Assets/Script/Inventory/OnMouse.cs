using TMPro;
using UnityEngine;

public class OnMouse : MonoBehaviour
{
    public string Title;
    public string desc;
    public GameObject _object;
    public TextMeshProUGUI _Title;
    public TextMeshProUGUI _desc;

    public Vector2 mousePos;
    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        _object.SetActive(false);
    }

    private void OnMouseOver()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        _object.SetActive(true);
        _Title.SetText(Title);
        _desc.SetText(desc);
        _object.transform.position = new Vector2(mousePos.x, mousePos.y);
    }

    private void OnMouseExit()
    {
        _object.SetActive(false);
    }
}
