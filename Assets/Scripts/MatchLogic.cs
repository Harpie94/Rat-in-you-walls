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
    public Rigidbody Player1Rigid;
    public Rigidbody Player2Rigid;
    public GameObject RespawnP1;
    public GameObject RespawnP2;
    public GameObject Ball;
    public GameObject BallRespawn;

    // Start is called before the first frame update
    void Start()
    {
        ResetPos();
    }

    // Update is called once per frame
    void Update()
    {
        Player1Rigid = GetComponent<Rigidbody>();
        Player2Rigid = GetComponent<Rigidbody>();
    }

    public void ButMarqué()
    {
        Player1Rigid.constraints = RigidbodyConstraints.FreezePosition;
        Player2Rigid.constraints = RigidbodyConstraints.FreezePosition;
        ResetPos();

    }

    public void ResetPos()
    {
        Player1.gameObject.transform.position = RespawnP1.transform.position;
        Player2.gameObject.transform.position= RespawnP2.transform.position;
        Ball.gameObject.transform.position= BallRespawn.transform.position;
    }
}
