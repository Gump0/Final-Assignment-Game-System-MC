using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_script : MonoBehaviour
{
    public bool roundEnd = false;
    public int score;
    public int ammoLeft;
    public int citiesLeft;
    public int ammoScore;
    public int citiesScore;
    public Text Bonus_Points, Ammo_Text, Cities_Text;

    void Start()
    {
        Transform ammoPts = transform.Find("Ammo_Text");
        Ammo_Text = ammoPts.GetComponent<Text>();
        Transform cityPts = transform.Find("Cities_Text");
        Cities_Text = cityPts.GetComponent<Text>();
    }

    void Update()
    {
        if (roundEnd == true)
        {

            ammoScore = ammoLeft * 10;
            citiesScore = citiesLeft * 100;

            Ammo_Text.text = "Ammo: " + ammoScore.ToString();
            Cities_Text.text = "Cities: " + citiesScore.ToString();

            score = score + ammoScore + citiesScore;
        }
    }
}
