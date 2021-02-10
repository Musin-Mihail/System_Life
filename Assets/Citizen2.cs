using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen2 : MonoBehaviour
{
    public Vector3 house;
    public int Stop = 0;
    public int CollectedPlants;
    Rigidbody Body;
    public GameObject House;

    void Start()
    {
        house = transform.position;
        Body = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (House.GetComponent<House>().PlantedPlants.Count > 0)
        {
            Stop = 0;
            transform.LookAt(House.GetComponent<House>().PlantedPlants[0].transform.position);
            House.GetComponent<House>().PlantedPlants[0].name = "PlantRedTarget";
            Body.AddRelativeForce(Vector3.forward*200);
        }
        else if (Stop == 0)
        {
            transform.LookAt(house);
            Body.AddRelativeForce(Vector3.forward*200);
        } 
    }

    void OnTriggerEnter (Collider other)
    {
        if(other.name == "PlantRedTarget")
        {
            other.GetComponent<MeshRenderer>().enabled = true;
            House.GetComponent<House>().PlantedPlants.RemoveAt(0);
            CollectedPlants ++;
            Destroy(other.gameObject);
        }
        if(other.name == "Stop2" &&  Stop == 0)
        {
            Stop = 1;
        }
    }
}
