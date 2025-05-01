using UnityEngine;
using System.Collections;

public class FlieSpawning : MonoBehaviour

{
    public GameObject[] Flies = new GameObject[10];
    int numberOfFlies;
    IEnumerator FlieSpawningCoroutine()

    {

        while (numberOfFlies < Flies.Length)
        {
            Flies[numberOfFlies].SetActive(true);
            numberOfFlies++;   
            yield return new WaitForSeconds(1);
           
        }
    }

// Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
    {
        StartCoroutine(FlieSpawningCoroutine());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
