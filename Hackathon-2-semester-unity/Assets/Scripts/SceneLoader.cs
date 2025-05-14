using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public GameObject fadeScreen;
    float timeToFade = 4;
    float timeSpentFading;
    // Starts the fading coroutine
    public void NextScene()
    {
        fadeScreen.SetActive(true);
        StartCoroutine(FadeToNextScene());
    }
    // Fades out and swaps the scene when done
    IEnumerator FadeToNextScene()
    {
        while (timeSpentFading < timeToFade)
        {
            timeSpentFading += Time.deltaTime;
            fadeScreen.GetComponent<Image>().color = new Color(0, 0, 0, timeSpentFading / timeToFade);
            yield return null;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
