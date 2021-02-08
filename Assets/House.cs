using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public GameObject Citizen;
    public GameObject Plant;
    Vector3 target;
    public int Wait = 0;
    void Start()
    {
        
    }
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            if (Wait == 0)
            {
                Wait = 1;
                target = Random.insideUnitCircle * 100;
                Citizen.GetComponent<Citizen>().target = new Vector3(target.x, 3, target.y);
                Citizen.GetComponent<Citizen>().Stop = 0;
                var plant2 = Instantiate(Plant, new Vector3(target.x, 3, target.y), Quaternion.identity);
                plant2.name = "PlantWait";
            }
        }
    }
}
