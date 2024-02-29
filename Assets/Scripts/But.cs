using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class But : MonoBehaviour
{
    Collider ButCollider;
    public GameObject Cible;

    //1 ou 2
    public int TeamID;

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
            other.gameObject.transform.position = Cible.transform.position;
            Debug.Log("Équipe " + TeamID + " a marquée");
        }
        else
        {
        Debug.Log("AAAAAAA");
        }
    }
    
    public void MoveGameObject()
    {

    }
}

