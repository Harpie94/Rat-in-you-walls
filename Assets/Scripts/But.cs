using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class But : MonoBehaviour
{
    Collider ButCollider;

    // Start is called before the first frame update
    void Start()
    {
        ButCollider = GetComponent<Collider>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Sphere") {
            Debug.Log("Balle trouvée");
            
        }
        Debug.Log("AAAAAAA");
    }
    
    public void MoveGameObject()
    {

    }
}

