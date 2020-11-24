﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time : MonoBehaviour
{
    private int playTime = 21600;
    private int minutes = 0;
    private int hours = 6;
    private int days = 0;

    //Text
    public Text timeDisplay;

    // Start is called before the first frame update
    void Start()
    {
        timeDisplay.text = "Time: 6:00";
        StartCoroutine(PlayTimer());
    }

    private IEnumerator PlayTimer(){
        while(true){
            yield return new WaitForSeconds(60);
            playTime += 1800; // 30 min in seconds
            minutes = (playTime / 60) % 60;
            hours = (playTime / 3600) % 24;
            days = (playTime / 86400) % 365;
        }
    }

    void Update(){
        if(minutes != 30){
            timeDisplay.text = "Time: " + hours.ToString() + ":00";
        } else {
            timeDisplay.text = "Time: " + hours.ToString() + ":30";
        }
    }
}
