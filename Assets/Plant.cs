using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    int Stage = 0;
    void Start()
    {
        StartCoroutine(Growth());
    }

    void Update()
    {
        if (Stage == 1)
        {
            GetComponent<MeshRenderer>().material.color = Color.green;
        }
        if (Stage == 2)
        {
            // Destroy(gameObject);
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
    IEnumerator Growth ()
    {
        yield return new WaitForSeconds(5);
        Stage = 1;
        yield return new WaitForSeconds(10);
        Stage = 2;
    }
}
