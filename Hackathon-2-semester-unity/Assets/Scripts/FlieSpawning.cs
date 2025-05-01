using UnityEngine;
using System.Collections;

public class FlieSpawning : MonoBehaviour
{
    public GameObject[] Flies = new GameObject[10];
    int numberOfFlies;
    public GameObject nextArrow;
    void Start()
    {
        StartCoroutine(FlieSpawningCoroutine());
    }

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
