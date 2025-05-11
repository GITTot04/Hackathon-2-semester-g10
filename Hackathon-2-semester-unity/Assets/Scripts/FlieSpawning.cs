using UnityEngine;
using System.Collections;

public class FlieSpawning : MonoBehaviour
{
    public GameObject[] Flies = new GameObject[10];
    int numberOfFlies;
    public GameObject nextArrow;
    // Starts the fly spawning coroutine
    void Start()
    {
        StartCoroutine(FlieSpawningCoroutine());
    }
    // Spawns a new fly every second until all flies are spawned and then activates the next arrow
    IEnumerator FlieSpawningCoroutine()
    {
        while (numberOfFlies < Flies.Length)
        {
            Flies[numberOfFlies].SetActive(true);
            numberOfFlies++;
            yield return new WaitForSeconds(1);
        }
        nextArrow.SetActive(true);
    }
}
