using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;
using UnityEngine.UI;

//21-07-2020   VERSION SPAWNER 1.000
//*******POR**OMEGA&NAKO************
public class RandomSpawner : MonoBehaviour
{
    public GameObject prefab1;
    public float spawnRate = 2f;
    float nextSpawn = 0f;
    public int numMaxObject = 7;
    int counter = 0;
    public float minX=0, maxX=5, minZ=0, maxZ=5;
    RaycastHit ray;
    public Transform trans;
    public float offSet = 0.5f;
    public Collider col;
   

    //==================================================================================================================
    //Instancia los objetos
    void Spawn(RaycastHit hit)
    {
        Instantiate(prefab1, new Vector3(trans.position.x, hit.point.y + offSet, trans.position.z), Quaternion.identity);
    }
    //===================================================================================================================
    //===================================================================================================================
    //Detector Raycast
    void Detector()
    {
        RaycastHit hit;
        if (Physics.Raycast(trans.position, -Vector3.up, out hit))
        {
            print("Found an object - distance: " + hit.distance);
            Debug.DrawLine(trans.position, hit.point);

            Spawn(hit);
            
        }
    }
    //====================================================================================================================
    //====================================================================================================================
    //Estructura del contador de objetos
    void Counter()
    {
        if (counter < numMaxObject)
        {

            Transform tr = trans;
            trans.position += new Vector3(Random.Range(minX, maxX), 0f, Random.Range(minZ, maxZ));

            Detector();
            trans = tr;

            nextSpawn = Time.time + spawnRate;
            ++counter;
        }
    }
    //====================================================================================================================
    //====================================================================================================================
    void SpawnerTimer()
    {
        if (Time.time > nextSpawn)
        {

            Counter();
        }
    }
    void Start()
    {
        col = GetComponent<Collider>();
    }

    void Update()
    {

        SpawnerTimer();

    }
   

}
