using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class But : MonoBehaviour
{
    Collider ButCollider;
    public GameObject Cible;

    //1 ou 2
    public int TeamID;
    public GameObject Balle;
    public bool GoalScored;


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
        if (Balle.gameObject.name == "Ball") {

            GoalScored = true;
            Debug.Log("Balle trouv�e");
            Balle.gameObject.transform.position = Cible.transform.position;
            Debug.Log("�quipe " + TeamID + " a marqu�e");
            Cible.GetComponent<MatchLogic>().ButMarqu�();

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

