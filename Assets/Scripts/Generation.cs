using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Generation : MonoBehaviour
{

    public GameObject[] Obstacles;
    public GameObject[] Limites;
    public int NbrObstaclesMin;
    public int NbrObstaclesMax;
    public int Rotation90;

    void Start()
    {
        //Récupère les coordonnées X et Z des limites ainsi que le Y du spawner
        float LimitesX1 = Limites[0].gameObject.GetComponent<Transform>().position.x;
        float LimitesZ1 = Limites[0].gameObject.GetComponent<Transform>().position.z;
        float LimitesX2 = Limites[1].gameObject.GetComponent<Transform>().position.x;
        float LimitesZ2 = Limites[1].gameObject.GetComponent<Transform>().position.z;
        float LimiteY = transform.position.y;

        //génère les objets 
        int NbrObstacles = Random.Range(NbrObstaclesMin, NbrObstaclesMax);
        int i = 0;
        while (i < NbrObstacles) {
            int randomID = Random.Range(0, Obstacles.Length);
            Vector3 randomSpawnPos = new Vector3(Random.Range(LimitesX1, LimitesX2), LimiteY, Random.Range(LimitesZ1, LimitesZ2));
            int RandomRotaX = Random.Range(0, 1);
            int RandomRotaY = Random.Range(0, 361);
            int RandomRotaZ = Random.Range(0, 1);
            if (randomID >= 0  && randomID < Rotation90) 
            {
                Instantiate(Obstacles[randomID], randomSpawnPos, Quaternion.Euler(-90,RandomRotaY,0));
            }
            else
            {
                Instantiate(Obstacles[randomID], randomSpawnPos, Quaternion.Euler(0, RandomRotaY, 0));
            }
            Debug.Log("Obstacle "+Obstacles[randomID]+" créé");
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}