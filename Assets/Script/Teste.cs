using UnityEngine;
using UnityEngine.UI;

public class Teste : MonoBehaviour
{
    public Image img;
    public AlertManager alertManager;

    // Start is called before the first frame update
    void Start()
    {
        alertManager.NotificationAlertManager(img, "Tempête radioactive en approche", "Un tempête radioactive est sur le point de se produire", 7);
    }

}
