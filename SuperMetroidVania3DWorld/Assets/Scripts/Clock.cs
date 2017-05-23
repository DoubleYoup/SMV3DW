using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Clock : MonoBehaviour 
    {

    public Transform hours, minitues, seconds;

    private const float 
        hoursToDegrees = 360f/12f,
        minitesToDegrees = 360f/60f,
        secondsToDegrees = 360f/60f;


    public bool analog;

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (analog)
        {
            TimeSpan timeSpan = DateTime.Now.TimeOfDay;
            hours.localRotation = Quaternion.Euler(0f,0f,(float)timeSpan.TotalHours * -hoursToDegrees);
            minitues.localRotation = Quaternion.Euler(0f,0f,(float)timeSpan.TotalMinutes * -minitesToDegrees);
            seconds.localRotation = Quaternion.Euler(0f,0f,(float)timeSpan.TotalSeconds * -secondsToDegrees);
        }
        else
        {
            DateTime time = DateTime.Now;
            hours.localRotation = Quaternion.Euler(0f, 0f, time.Hour * -hoursToDegrees);
            minitues.localRotation = Quaternion.Euler(0f, 0f, time.Minute * -minitesToDegrees);
            seconds.localRotation = Quaternion.Euler(0f, 0f, time.Second * -secondsToDegrees);
        }
	}
}
