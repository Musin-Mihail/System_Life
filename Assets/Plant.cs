using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public GameObject House;

    void Start()
    {
        StartCoroutine(Growth());
    }
    
    IEnumerator Growth ()
    {
        yield return new WaitForSeconds(5);
        GetComponent<MeshRenderer>().material.color = Color.green;
        gameObject.name = "PlantGreen";
        yield return new WaitForSeconds(10);
        GetComponent<MeshRenderer>().material.color = Color.red;
        gameObject.name = "PlantRed";
        House.GetComponent<House>().PlantedPlants.Add(gameObject);
    }
}