using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JetpackSlider : MonoBehaviour
{
    [Range(0,15)]

    public float MaxJetpackFuel;
    public float JetpackFuel;


    public GameObject Player;
    public RectTransform UIbar;

    float percentUnit;
    float JetpackPercentUnit;
    private void Start()
    {
        MaxJetpackFuel = Player.GetComponent<Joueur>().maxJetpackFuel;
        JetpackFuel = Player.GetComponent<Joueur>().currentJetpackFuel;

        percentUnit = 1f / UIbar.anchorMax.y;
        JetpackPercentUnit = 100f / Player.GetComponent<Joueur>().maxJetpackFuel;

       
    }

    private void Update()
    {
        
        if (Player.GetComponent<Joueur>().currentJetpackFuel > Player.GetComponent<Joueur>().maxJetpackFuel) JetpackFuel = Player.GetComponent<Joueur>().maxJetpackFuel;
        else if (Player.GetComponent<Joueur>().currentJetpackFuel < 0) Player.GetComponent<Joueur>().currentJetpackFuel = 0;
        float CurrentJetpackPercent = Player.GetComponent<Joueur>().currentJetpackFuel * JetpackPercentUnit;

        UIbar.anchorMax = new Vector2(UIbar.anchorMax.x, (CurrentJetpackPercent * percentUnit) / 100f);

    }
}