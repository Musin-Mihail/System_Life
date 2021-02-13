using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCitizen : MonoBehaviour
{
    public Vector3 Target;
    public Vector3 NewTarget;
    Rigidbody Body;
    Collider[] hitColliders;
    public GameObject House;
    public GameObject Cam;
    int layerMask = 1 << 7; //House
    void Start()
    {
        Cam = 
        House =  Resources.Load<GameObject>("House");
        Body = GetComponent<Rigidbody>();
        Target = Random.insideUnitCircle * 50;
        NewTarget = new Vector3(Target.x + transform.position.x, 2, Target.y + transform.position.z);
        transform.LookAt(NewTarget);
        StartCoroutine(FindHouse());
    }

    void Update()
    {
        Body.AddRelativeForce(Vector3.forward*200);
        // transform.position = Vector3.MoveTowards(transform.position, transform.forward, Time.deltaTime*10);
    }

    IEnumerator FindHouse()
    {
        while(true)
        {
            hitColliders = Physics.OverlapSphere(transform.position, 90, layerMask);
            if(hitColliders.Length == 0)
            {
                var NewHouse = Instantiate(House, transform.position, Quaternion.identity);
                NewHouse.transform.position = new Vector3 (transform.position.x, transform.position.y+8,transform.position.z);
                if(Global.Distant < 1000)
                {
                    Global.Distant += 15;
                }
                else if(Global.Distant < 1500)
                {
                    Global.Distant += 10;
                }
                else if(Global.Distant < 2000)
                {
                    Global.Distant += 5;
                }
                else
                {
                    Global.Distant += 2;
                }

                Camera.main.transform.position = -Camera.main.transform.forward*Global.Distant;
                Destroy(gameObject);
            }
            yield return new WaitForSeconds(0.5f); 
        }
    }
}
