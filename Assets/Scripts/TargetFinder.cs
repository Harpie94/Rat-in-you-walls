using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFinder : MonoBehaviour
{


    public Transform Cible;
    public float RotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion targetRotation = Quaternion.LookRotation(Cible.position - transform.position);
        Quaternion addedRotation = Quaternion.Euler(0, 90, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation * addedRotation, RotationSpeed * Time.deltaTime);
    }
}

