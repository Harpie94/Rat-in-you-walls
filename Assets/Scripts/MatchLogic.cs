using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public float PointsJ1 = 0;
    public float PointsJ2 = 0;
    public bool MatchEnd = false;

    public bool VainqueurJ1 = false;
    public bool VainqueurJ2 = false;

    public GameObject Timer;
    public GameObject HUD;


    public TextMeshProUGUI CompteurJ1;
    public TextMeshProUGUI CompteurJ2;

    public float PointsCible = 5;

    // Start is called before the first frame update
    void Start()
    {
        ResetPos();
        Player1.GetComponent<Joueur>().PlayerUnFreezePos();
        Player2.GetComponent<Joueur>().PlayerUnFreezePos();
        Time.timeScale = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        //Si un joueur à un score = 5 > fin de match, si égalitée (4/4) le premier à 6 gagne, ect... 
        if ((PointsJ1 >= PointsCible || PointsJ2 >= PointsCible) && (PointsJ1 >= PointsJ2 + 2 || PointsJ2 >= PointsJ1 + 2))
        {
            EndMatch();
            Timer.gameObject.GetComponent<Timer>().TimerOn = false;
        }

        if (PointsJ1 == PointsCible - 1 && PointsJ2 == PointsCible - 1)
        {
            PointsCible++;
            UpdatePoints();
        }
    }

    //Reset les positions de joueurs et Freeze les joueurs le temps de la tp
    public void ButMarqué()
    {
        Timer.gameObject.GetComponent<Timer>().TimerOn = false;
        Player1.GetComponent<Joueur>().PlayerFreezePos();
        Player2.GetComponent<Joueur>().PlayerFreezePos();
        ResetPos();
        Player1.GetComponent<Joueur>().PlayerUnFreezePos();
        Player2.GetComponent<Joueur>().PlayerUnFreezePos();
        Ball.GetComponent<Ball>().BallUnFreezeRota();
        Timer.gameObject.GetComponent<Timer>().TimerOn = true;
    }

    
    //Récupère les points des 2 buts et les mets à jours dans le MatchLogic
    public void UpdatePoints()
    {
        
        PointsJ1 = ButJ1.GetComponent<But>().PointsT1;
        PointsJ2 = ButJ2.GetComponent<But>().PointsT2;

        float printPointsJ1 = PointsJ1;
        float printPointsJ2 = PointsJ2;
        float MaxPoints = PointsCible;
        CompteurJ1.text = string.Format("{0} / {1}", printPointsJ1, MaxPoints);
        CompteurJ2.text = string.Format("{0} / {1}", printPointsJ2, MaxPoints);

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
        Player1.GetComponent<Joueur>().PlayerFreezePos();
        Player2.GetComponent<Joueur>().PlayerFreezePos();
        Ball.GetComponent<Ball>().BallFreezeRota();
        if (PointsJ1 > PointsJ2)
        {
            VainqueurJ1 = true;
            HUD.GetComponent<PauseMenu>().J1Victory = true;
        }
        else if (PointsJ2 > PointsJ1)
        {
            VainqueurJ2 = true;
            HUD.GetComponent<PauseMenu>().J2Victory = true;
        }
        else
        {
            HUD.GetComponent<PauseMenu>().Tie = true;
        }
    }
}
