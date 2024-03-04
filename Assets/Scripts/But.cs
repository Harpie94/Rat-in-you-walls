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
        if (other.gameObject.name == "Ball") {

            GoalScored = true;
            Balle.GetComponent<Ball>().BallFreezeRota();
            Debug.Log("Balle trouvée");
            other.gameObject.transform.position = Cible.transform.position;
            Debug.Log("Équipe " + TeamID + " a marquée");
            AddPoints();
            Cible.GetComponent<MatchLogic>().ButMarqué();
            
        }
        else
        {
        Debug.Log("AAAAAAA");
        }
    }

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
    }

    public void MoveGameObject()
    {

    }
}

