using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;




public class Timer : MonoBehaviour
{
    public float TimerLeft;
    public bool TimerOn = false;



    public GameObject MatchLogic;
    public TextMeshProUGUI TimerTxt;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        TimerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerOn)
        {
            if (TimerLeft > 0)
            {
                            
                TimerLeft -= Time.deltaTime;
                updateTimer(TimerLeft);
            }
            else
            {
                MatchLogic.gameObject.GetComponent<MatchLogic>().EndMatch();
                TimerLeft = 0;
                TimerOn = false;
                
            }
        }

    }


    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float Minutes = Mathf.FloorToInt(currentTime / 60);
        float Seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{0:00} : {1:00}", Minutes, Seconds);
    }

}

