using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Bloque la balle
    public void BallFreezeRota()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.constraints = RigidbodyConstraints.FreezePosition;

    }//Débloque la balle
    public void BallUnFreezeRota()
    {
        rb.constraints = RigidbodyConstraints.None;
    }
}
