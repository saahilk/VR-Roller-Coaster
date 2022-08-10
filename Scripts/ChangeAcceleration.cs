using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAcceleration : MonoBehaviour
{
    public float acceleration;
    // Start is called before the first frame update
    

    private void OnTriggerEnter(Collider other){
        Debug.Log("Triggered: " + gameObject.name);
        GameObject cart = GameObject.FindGameObjectsWithTag("Cart")[0];
        cart.GetComponent<MoveCart>().changeAcceleration(acceleration);
    }
}
