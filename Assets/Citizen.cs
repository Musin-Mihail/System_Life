using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : MonoBehaviour
{
    public Vector3 target;
    public Vector3 house;
    public int Stop = 0;
    Rigidbody Body;
    public GameObject House;
    void Start()
    {
        target = transform.position;
        house = transform.position;
        Body = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if(Stop == 0)
        {
            transform.LookAt(target);
            Body.AddRelativeForce(Vector3.forward*100);
        }
            
    }
    void OnTriggerEnter (Collider other)
    {
        Debug.Log(target);
        if(other.name == "PlantWait")
        {
            other.name = "Plant";
            other.GetComponent<MeshRenderer>().enabled = true;
            target = house;
            House.GetComponent<House>().Wait = 0;
            
        }
        if(other.name == "Stop" &&  target == house)
        {
            Stop = 1;
        }
    }
}
