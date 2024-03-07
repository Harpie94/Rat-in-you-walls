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
    public bool VainqueurJ1 = false;
    public bool VainqueurJ2 = false;


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
        //Si un joueur à un score = 5 > fin de match, si égalitée (4/4) le premier à 6 gagne, ect... 
        if ((PointsJ1 >= 5 || PointsJ2 >= 5) && (PointsJ1 >= PointsJ2 + 2 || PointsJ2 >= PointsJ1 + 2))
        {
            if (PointsJ1 > PointsJ2)
            {
                VainqueurJ1 = true;
            }
            else if (PointsJ2 > PointsJ1) 
            { 
                VainqueurJ2 = true; 
            }
            EndMatch();
            Player1.GetComponent<Joueur>().PlayerFreezePos();
            Player2.GetComponent<Joueur>().PlayerFreezePos();
            Ball.GetComponent<Ball>().BallFreezeRota();

        }
    }
    //Reset les positions de joueurs et Freeze les joueurs le temps de la tp
    public void ButMarqué()
    {

        Player1.GetComponent<Joueur>().PlayerFreezePos();
        Player2.GetComponent<Joueur>().PlayerFreezePos();
        ResetPos();
        Player1.GetComponent<Joueur>().PlayerUnFreezePos();
        Player2.GetComponent<Joueur>().PlayerUnFreezePos();
        Ball.GetComponent<Ball>().BallUnFreezeRota();
    }

    //Récupère les points des 2 buts et les mets à jours dans le MatchLogic
    public void UpdatePoints()
    {
        PointsJ1 = ButJ1.GetComponent<But>().PointsT1;
        PointsJ2 = ButJ2.GetComponent<But>().PointsT2;
    }

    //Reset les positions de joueurs
    public void ResetPos()
    {
        
        Player1.gameObject.transform.position = RespawnP1.transform.position;
        Player2.gameObject.transform.position= RespawnP2.transform.position;
        Ball.gameObject.transform.position= BallRespawn.transform.position;


    }

    //Active la fin du Match
    public void EndMatch()
    {
        MatchEnd = true;
    }
}
