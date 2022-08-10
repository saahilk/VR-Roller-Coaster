using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpeed : MonoBehaviour
{
    public float acceleration;
    public float speed;
    // Start is called before the first frame update
    

    private void OnTriggerEnter(Collider other){
        GameObject cart = GameObject.FindGameObjectsWithTag("Cart")[0];
        cart.GetComponent<MoveCart>().changeAcceleration(acceleration);
        cart.GetComponent<MoveCart>().changeSpeed(speed);
    }
}
