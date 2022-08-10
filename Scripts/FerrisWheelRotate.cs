using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FerrisWheelRotate : MonoBehaviour
{
    // Start is called before the first frame update
    Transform ferris;
    public Transform ferrisPosition;
    public GameObject playerObj;
    public float degree;
    public Transform gondolaParent;
    public Camera player;
    private float rotated;
    void Start()
    {
        rotated = 0.0f;
        SkinnedMeshRenderer r = this.GetComponent<SkinnedMeshRenderer>();
        ferris = r.rootBone;
        // Debug.Log(gameObject.name);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rotated >= 360.0f){
            for(var i = 2;i<=13;i++){
                // Debug.Log("Child:  " + gondolaParent.GetChild(i).gameObject.name);
                gondolaParent.GetChild(i).gameObject.GetComponent<RotateGondola>().enabled = false;
            }
            player.GetComponent<GazeController>().endFerrisRide();
            rotated = 0.0f;
        }
        else {
            // Debug.Log(rotated);
            ferris.Rotate(new Vector3(0.0f,degree,0.0f));
            Vector3 pos = new Vector3(ferrisPosition.position.x-4.95f,ferrisPosition.position.y-10.3f,ferrisPosition.position.z+7.44f);
            playerObj.transform.position = pos; 
            rotated += degree;
        }
    }

    public void startGondolas(){
        for(var i = 2;i<=13;i++){
            Debug.Log("Child:  " + gondolaParent.GetChild(i).gameObject.name);
            gondolaParent.GetChild(i).gameObject.GetComponent<RotateGondola>().enabled = true;
            gondolaParent.GetChild(i).gameObject.GetComponent<RotateGondola>().setDegree(degree);
        }
    }

    
}
