using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMode : MonoBehaviour
{

    public Camera camera;
    public GameObject armature;
    public GameObject armaturetp;
    public GameObject Dot;
    public Button confirm;
    public GameObject dialog;
    public Button cancel;
    bool isfpsView = true;

    // Start is called before the first frame update
    void Start()
    {
        fpsView();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("joystick 1 button 3") || Input.GetKeyDown("1")){
            if(isfpsView){
                thirdPersonView();
            }
            else{
                fpsView();
            }
            isfpsView = !isfpsView;
        }
        else if(Input.GetKeyDown("joystick 1 button 10") || Input.GetKeyDown("2")){
            if(dialog.active){
                confirm.onClick.Invoke();
                dialog.SetActive(false);
                camera.GetComponent<GazeController>().enabled = true;
            }
        }
        else if(Input.GetKeyDown("joystick 1 button 5") || Input.GetKeyDown("3")){
            if(dialog.active){
                cancel.onClick.Invoke();
                dialog.SetActive(false);
                camera.GetComponent<GazeController>().enabled = true;
            }
        }
    }

    public void fpsView(){
        armature.SetActive(true);
        armaturetp.SetActive(false);
        armaturetp.GetComponent<Animator>().enabled = false;
        camera.transform.localPosition = new Vector3(0.0f,0.0f,0.0f);
        camera.GetComponent<GazeController>().enabled = true;
        Dot.SetActive(true);
    }

    public void thirdPersonView(){
        armature.SetActive(false);
        armaturetp.SetActive(true);
        armaturetp.GetComponent<Animator>().enabled = true;
        camera.transform.localPosition = new Vector3(0.1f,3f,-12f);
        camera.GetComponent<GazeController>().enabled = false;
        Dot.SetActive(false);
    }
}
