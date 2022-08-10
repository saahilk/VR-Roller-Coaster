using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGondola : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform gondola;
    private float degree;
    
    // Update is called once per frame
    void Update()
    {
        gondola.Rotate(new Vector3(0.0f,0.0f,degree));
    }

    public void setDegree(float deg){
        degree = deg;
    }
}
