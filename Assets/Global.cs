using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    static public GameObject AllPlants2;
    static public int Distant = 100;
    void Awake()
    {
        AllPlants2 = GameObject.Find("Plants");
    }
}