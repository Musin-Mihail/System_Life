using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public GameObject Citizen;
    public GameObject Plant;
    public GameObject Plants;
    int layerMask1 = 1 << 6;// Plant
    int layerMask2 = 1 << 7; //House
    int layerMask3;
    public Vector3 target;
    public int Wait = 0;
    public List<GameObject> AllPlant;
    public List<GameObject> PlantedPlants;
    void Start()
    {
        Plants = Global.AllPlants2;
        AllPlant = new List<GameObject>();
        PlantedPlants = new List<GameObject>();
        layerMask3 = layerMask1 | layerMask2;
        StartCoroutine(Planting());
    }
    
    IEnumerator Planting ()
    {
        yield return new WaitForSeconds(2);
        while(true)
        {
                var hitColliders = Physics.OverlapSphere(transform.position, 50, layerMask1);
                if(hitColliders.Length < 20)
                {
                    target = Random.insideUnitCircle * 50;
                    var NewTarget = new Vector3(target.x + transform.position.x, 2, target.y + transform.position.z);
                    var hitColliders2 = Physics.OverlapSphere(NewTarget, 5, layerMask3);
                    if(hitColliders2.Length  == 0)
                    {
                        var plant2 = Instantiate(Plant, NewTarget, Quaternion.identity);
                        plant2.transform.parent = Plants.transform;
                        AllPlant.Add(plant2);
                        plant2.name = "PlantWait";
                    }
                }
            yield return new WaitForSeconds(0.1f); 
        }
    }
}
