using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Introduction : MonoBehaviour
{
    public Animator animator;
    public bool isItInLoading;

    // Start is called before the first frame update
    void Start()
    {
        isItInLoading = false;
        StartCoroutine(Wait());
    }

    private void Update()
    {
        animator.SetBool("isItInLoading", isItInLoading);
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        isItInLoading = true;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadSceneAsync("MenuScene");
    }
}
