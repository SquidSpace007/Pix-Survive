using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RunningAnimation : MonoBehaviour
{
    public GameObject Img1;
    public GameObject Img2;
    public GameObject Img3;
    public GameObject Img4;
    public GameObject Img5;
    public GameObject Img6;

    public GameObject load1;
    public GameObject load2;
    public GameObject load3;

    // Start is called before the first frame update
    void Start()
    {
        load1.SetActive(false);
        load2.SetActive(false);
        load3.SetActive(false);
        Img1.SetActive(false);
        Img2.SetActive(false);
        Img3.SetActive(false);
        Img4.SetActive(false);
        Img5.SetActive(false);
        Img6.SetActive(false);
        AnimationManagement();
        LoadingAnimationManagement();
    }
    
    void AnimationManagement()
    {
        StartCoroutine(WalkAnimation());
    }

    void LoadingAnimationManagement()
    {
        StartCoroutine(LoadingAnimation());
    }

    public IEnumerator WalkAnimation()
    {
        Img1.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Img1.SetActive(false);
        Img2.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Img2.SetActive(false);
        Img3.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Img3.SetActive(false);
        Img4.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Img4.SetActive(false);
        Img5.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Img5.SetActive(false);
        Img6.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Img6.SetActive(false);
        AnimationManagement();
    }

    public IEnumerator LoadingAnimation()
    {
        load1.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        load1.SetActive(false);
        load2.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        load2.SetActive(false);
        load3.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        load3.SetActive(false);
        LoadingAnimationManagement();
    }
}
