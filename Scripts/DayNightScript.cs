using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class DayNightScript : MonoBehaviour
{
    public float time;
    public float dayLength;

    public GameObject bigLight;
    public TimeSpan currentTime;
    public Transform SunTransform;
    public Light Sun;
    public GameObject[] headlights = new GameObject[2];

    public Light cartlight1;
    public Light cartlight2;

    public GameObject Moon;

    // public int speed;

    // Update is called once per frame
    void Update()
    {
        ChangeTime();
        if((time>69000 || time<20000) && !Moon.active){
            Moon.SetActive(true);
            cartlight1.enabled = true;
            // cartlight1.GetComponent<Light>().enabled = true;
            cartlight2.enabled= true;
            // cartlight2.GetComponent<Light>().enabled = true;
            toggleLights(true);
        }
        else if((time<=69000 && time>=20000) && Moon.active) {
            Moon.SetActive(false);
            cartlight1.enabled= false;
            // cartlight1.GetComponent<Light>().enabled = false;
            cartlight2.enabled= false;
            // cartlight2.GetComponent<Light>().enabled = false;
            toggleLights(false);
        }
    }

    public void ChangeTime(){
        //we are making 86400 seconds in a day into daylength seconds
        time+= Time.deltaTime * (86400/dayLength);
        if(time>86400){
            time = 0;
        }
        currentTime = TimeSpan.FromSeconds (time);

        SunTransform.rotation = Quaternion.Euler(new Vector3((time-21600)/86400*360,0,0));

        if(time<43200){
            Sun.intensity = 1 - (43200-time)/43200;
        }
        else {
            Sun.intensity = 1 + (43200-time)/43200;
        }
    }

    public void toggleLights(bool state){
        foreach(GameObject hl in headlights){
            (hl.GetComponent("Halo") as Behaviour).enabled=state;
        }
        
        bigLight.SetActive(state);
    }
}
