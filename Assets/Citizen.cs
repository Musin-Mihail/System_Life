using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : MonoBehaviour
{
    public Vector3 Home;
    public int Stop = 0;
    Rigidbody Body;
    public GameObject House;

    void Start()
    {
        Home = transform.position;
        Body = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (House.GetComponent<House>().AllPlant.Count > 0)
        {
            Stop = 0;
            transform.LookAt(House.GetComponent<House>().AllPlant[0].transform.position);
            House.GetComponent<House>().AllPlant[0].name = "PlantTarget";
            // Body.AddRelativeForce(Vector3.forward*200);
            transform.position = Vector3.MoveTowards(transform.position, House.GetComponent<House>().AllPlant[0].transform.position, Time.deltaTime*100);
        }
        else if (Stop == 0)
        {
            transform.LookAt(Home);
            // Body.AddRelativeForce(Vector3.forward*200);
            transform.position = Vector3.MoveTowards(transform.position, Home, Time.deltaTime*100);

        } 
    }

    void OnTriggerEnter (Collider other)
    {
        if(other.name == "PlantTarget")
        {
            Stop = 1;
            other.name = "Plant";
            other.GetComponent<MeshRenderer>().enabled = true;
            House.GetComponent<House>().AllPlant[0].AddComponent<Plant>();
            other.GetComponent<Plant>().House = House;
            House.GetComponent<House>().AllPlant.RemoveAt(0);
            Stop = 0;
        }
        if(other.name == "Stop" &&  Stop == 0)
        {
            Stop = 1;
        }
    }
}