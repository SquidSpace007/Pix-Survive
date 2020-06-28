using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class ButtonManagement : MonoBehaviour
{
    public string levelToLoad;

    public GameObject panel;

    public Slider slider;

    public Text text;

    public void PlayButton(int sceneIndex)
    {
        StartCoroutine(LoadAsync(sceneIndex));
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void OptionButton()
    {
        Debug.Log("Non disponible pour le moment");
    }
    
    public IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        panel.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;
            text.text = progress + "%";

            Debug.Log(operation.progress);
            yield return null;
        }
    }
}
