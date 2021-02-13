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
    public GameObject _NewCitizen;

    void Start()
    {
        house = transform.position;
        Body = GetComponent<Rigidbody>();
        _NewCitizen =  Resources.Load<GameObject>("NewCitizen");
    }
    void Update()
    {
        if (House.GetComponent<House>().PlantedPlants.Count > 0)
        {
            Stop = 0;
            transform.LookAt(House.GetComponent<House>().PlantedPlants[0].transform.position);
            House.GetComponent<House>().PlantedPlants[0].name = "PlantRedTarget";
            // Body.AddRelativeForce(Vector3.forward*200);
            transform.position = Vector3.MoveTowards(transform.position, House.GetComponent<House>().PlantedPlants[0].transform.position, Time.deltaTime*100);
        }
        else if (Stop == 0)
        {
            transform.LookAt(house);
            // Body.AddRelativeForce(Vector3.forward*200);
            transform.position = Vector3.MoveTowards(transform.position, house, Time.deltaTime*100);
        } 
    }

    void OnTriggerEnter (Collider other)
    {
        if(other.name == "PlantRedTarget")
        {
            Stop = 1;
            other.GetComponent<MeshRenderer>().enabled = true;
            House.GetComponent<House>().PlantedPlants.RemoveAt(0);
            CollectedPlants ++;
            Destroy(other.gameObject);
            if(CollectedPlants > 10)
            {
                NewCitizen();
                CollectedPlants -= 10;
            }
            Stop = 0;
        }
        if(other.name == "Stop2" &&  Stop == 0)
        {
            Stop = 1;
        }
    }
    void NewCitizen() 
    {
        var plant2 = Instantiate(_NewCitizen, transform.position, Quaternion.identity);
    }
}
