using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public GameObject Citizen;
    public GameObject Plant;
    int layerMask1 = 1 << 6;// Plant
    int layerMask2 = 1 << 7; //House
    int layerMask3;
    Vector3 target;
    public int Wait = 0;
    void Start()
    {
        layerMask3 = layerMask1 | layerMask2;
        StartCoroutine(Planting());
    }
    // void Update()
    // {

    // }
    IEnumerator Planting ()
    {
        yield return new WaitForSeconds(2);
        while(true)
        {
            if (Wait == 0)
            {
                var hitColliders = Physics.OverlapSphere(transform.position, 50, layerMask1);
                if(hitColliders.Length < 1000)
                {
                    target = Random.insideUnitCircle * 50;
                    var NewTarget = new Vector3(target.x, 5, target.y);
                    var hitColliders2 = Physics.OverlapSphere(NewTarget, 3, layerMask3);
                    if(hitColliders2.Length  == 0)
                    {
                        Wait = 1;
                        Citizen.GetComponent<Citizen>().target = NewTarget;
                        Citizen.GetComponent<Citizen>().Stop = 0;
                        var plant2 = Instantiate(Plant, NewTarget, Quaternion.identity);
                        plant2.name = "PlantWait";
                    }
                }
            }
            yield return new WaitForSeconds(0.5f);   
        }
    }
}
