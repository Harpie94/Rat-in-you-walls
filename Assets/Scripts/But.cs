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

    public int PointsT1 = 0;
    public int PointsT2 = 0;

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
        //V�rifie si l'objet dans la cage est la balle
        if (other.gameObject == Balle) {

            GoalScored = true;
            Balle.GetComponent<Ball>().BallFreezeRota();
            Debug.Log("Balle trouv�e");
            other.gameObject.transform.position = Cible.transform.position;
            Debug.Log("�quipe " + TeamID + " a marqu�e");
            AddPoints();
            Cible.GetComponent<MatchLogic>().ButMarqu�();
            
        }
        else
        {
        Debug.Log("AAAAAAA");
        }
    }

    //Ajoute un points selon l'�quipe affect�e au but
    public void AddPoints()
    {
        if (TeamID == 1)
        {
            PointsT1++;
        }
        else if (TeamID == 2)
        {
            PointsT2++;
        }
        Cible.GetComponent<MatchLogic>().UpdatePoints();
        GoalScored = false;
    }

}

