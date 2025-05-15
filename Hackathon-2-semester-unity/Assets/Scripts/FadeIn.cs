using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public GameObject fadeScreen;
    [SerializeField] float timeToFade = 1.5f;
    float timeSpentFading;
    // Starts the fade in coroutine
    private void Start()
    {
        fadeScreen.SetActive(true);
        fadeScreen.GetComponent<Image>().color = new Color(0, 0, 0, 1);
        StartCoroutine(FadeInCoroutine());
    }
    // Fades in
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
