using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRocket : MonoBehaviour
{
    // Start is called before the first frame update
    private int ctr;
    private bool reverse;
    void Start()
    {
        ctr = 0;
        reverse = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!reverse){
            gameObject.transform.Translate(0,0,1);
            if(gameObject.transform.position.y>=90){
                reverse=!reverse;
            }
        }
        else {
            gameObject.transform.Translate(0,0,-1);
            if(gameObject.transform.position.y<=61){
                reverse=!reverse;
                ctr+=1;
                if(ctr>5){
                    this.enabled = false;
                }
            }
        }
    }
}
