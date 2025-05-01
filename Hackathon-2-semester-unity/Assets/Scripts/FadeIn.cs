using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public GameObject fadeScreen;
    float timeToFade = 4;
    float timeSpentFading;
    private void Start()
    {
        fadeScreen.SetActive(true);
        fadeScreen.GetComponent<Image>().color = new Color(0, 0, 0, 1);
        StartCoroutine(FadeInCoroutine());
    }

    IEnumerator FadeInCoroutine()
    {
        while (timeSpentFading < timeToFade)
        {
            timeSpentFading += Time.deltaTime;
            fadeScreen.GetComponent<Image>().color = new Color(0, 0, 0, 1 - (timeSpentFading / timeToFade));
            yield return null;
        }
        fadeScreen.SetActive(false);
    }
}
