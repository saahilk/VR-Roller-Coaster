using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCoasterRide : MonoBehaviour
{
    public Camera player;
    private void OnTriggerEnter(Collider other){
        Debug.Log("ending ride");
        player.GetComponent<GazeController>().endCoasterRide();
    }
}
