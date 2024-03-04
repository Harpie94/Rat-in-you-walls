using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchLogic : MonoBehaviour
{
    /*Team1
     * Team2
    PointsTeamA
    PointsTeamB
    TimeLeft
    PauseTimer
    PauseMatch*/

    public GameObject Player1;
    public GameObject Player2;
    public GameObject RespawnP1;
    public GameObject RespawnP2;
    public GameObject Ball;
    public GameObject BallRespawn;
    public GameObject ButJ1;
    public GameObject ButJ2;
    public int PointsJ1 = 0;
    public int PointsJ2 = 0;
    public bool MatchEnd = false;



    // Start is called before the first frame update
    void Start()
    {
        ResetPos();
        Player1.GetComponent<Joueur>().PlayerUnFreezePos();
        Player2.GetComponent<Joueur>().PlayerUnFreezePos();
    }

    // Update is called once per frame
    void Update()
    {
        if ((PointsJ1 >= 5 || PointsJ2 >= 5) && (PointsJ1 >= PointsJ2 + 2 || PointsJ2 >= PointsJ1 + 2)) 
        { 
            EndMatch();
            Player1.GetComponent<Joueur>().PlayerFreezePos();
            Player2.GetComponent<Joueur>().PlayerFreezePos();
            Ball.GetComponent<Ball>().BallFreezeRota();
        }
    }

    public void ButMarqué()
    {

        Player1.GetComponent<Joueur>().PlayerFreezePos();
        Player2.GetComponent<Joueur>().PlayerFreezePos();
        ResetPos();
        Player1.GetComponent<Joueur>().PlayerUnFreezePos();
        Player2.GetComponent<Joueur>().PlayerUnFreezePos();
        Ball.GetComponent<Ball>().BallUnFreezeRota();
    }

    public void UpdatePoints()
    {
        PointsJ1 = ButJ1.GetComponent<But>().PointsT1;
        PointsJ2 = ButJ2.GetComponent<But>().PointsT2;
    }
    public void ResetPos()
    {
        
        Player1.gameObject.transform.position = RespawnP1.transform.position;
        Player2.gameObject.transform.position= RespawnP2.transform.position;
        Ball.gameObject.transform.position= BallRespawn.transform.position;


    }

    public void EndMatch()
    {
        MatchEnd = true;
    }
}
