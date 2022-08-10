using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using PathCreation;

public class GazeController : MonoBehaviour
{
    public float rayLength = 500.0f;
    public Image circleLoader;
    public float gazeDuration;

    public GameObject dot;

    public GameObject dialog;

    public GameObject player;
    public GameObject camera;

    public Transform bone13;

    public Transform cartPosition;
    public Transform ferrisPosition;
    private RaycastHit _currentTarget;
    private Vector3 startPosition;
    private Vector3 cartStartPos;
    private Quaternion startRotation;
    private Quaternion cartStartRotation;
    private string _target;
    private string _previousTarget;
    private string selectedRide; 
    public GameObject cart;
    bool inCart = false;
    bool onFerris = false;
    private bool _isRadialFilled = false; 
    private float _timer;

    public GameObject ferris;
    void Start(){
        _previousTarget = null;
    }
    void Update()
    {
        GazeRaycast();
    }

    private void GazeRaycast()
    {
        RaycastHit hit; 
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0f));
        if(Physics.Raycast(ray, out hit, rayLength)){
            // Debug.Log("Camera ray:" + hit.transform.gameObject.tag);
            if (hit.transform.gameObject.tag != "Untagged")
            {
                _target = hit.transform.gameObject.tag;
                _currentTarget = hit;

                // Debug.Log(_target);
                // text.text = _target;
    
            }
            else{
                //no targets found
                _target = null;
            }
        }
        else{
            _target = null;
        }
        
        if(_target !=null  && _target != _previousTarget){
            if((_target=="Track" || _target=="Ferris") && (inCart || onFerris)){
                ResetProgress();
            }
            else{
                StartProgress();
                _previousTarget = _target;
            }

        }
        else if(_target!= null && _target == _previousTarget){
            // Debug.Log("Target : " + _target);
            if(ProgressRadialImage()){
                if(_target == "Ferris") {
                    selectedRide = "Ferris";
                    Debug.Log("Move to ferris");
                    displayDialog("Ride Ferris Wheel?");
                    enableGazeControl(false);
                }
                else if(_target == "Track"){
                    selectedRide = "RollerCoaster";
                    displayDialog("Ride Roller Coaster?");
                    enableGazeControl(false);
                }
                else if(_target == "Star"){
                    _currentTarget.transform.gameObject.GetComponent<RotateAlongZ>().enabled = true;
                }
                else if(_target=="UFO"){
                    _currentTarget.transform.gameObject.GetComponent<RotateAlongY>().enabled = true;
                }
                else if(_target=="Alien"){
                    StartCoroutine(alienSound(_currentTarget.transform.gameObject));
                }
                else if(_target=="Rocket"){
                    _currentTarget.transform.gameObject.GetComponent<MoveRocket>().enabled = true;
                }
            }
        }
        else {
            _target = null;
            _previousTarget = null;
            ResetProgress();
        }

    }

    IEnumerator alienSound(GameObject target){
        target.GetComponent<AudioSource>().enabled = true;
        yield return new WaitForSeconds(2);
        target.GetComponent<AudioSource>().enabled = false;

    }

    public void displayDialog(string text){
        Debug.Log(dialog.transform.GetChild(0).gameObject);
        // dialog.transform.GetChild(0).gameObject.text = text;
        dialog.SetActive(true);
    }

    public void enableGazeControl(bool isEnabled){
        dot.SetActive(isEnabled);
        this.enabled = isEnabled;
    }

    public void move(Vector3 vec){
        // Debug.Log("In move");

        player.SetActive(false);
        player.transform.position = vec;
        player.SetActive(true);
    }

    public void resetCamera(){
        camera.transform.localPosition = new Vector3(0.0f,0.0f,0.0f);
        camera.transform.localRotation = Quaternion.identity;
    }

    public void startRide(){
        // resetCamera();
        enableGazeControl(true);
        if(selectedRide=="Ferris"){
            startFerrisRide();
        }
        else if(selectedRide == "RollerCoaster"){
            startCoasterRide();
        }
    }

    public void closeDialog(){
        dialog.SetActive(false);
        enableGazeControl(true);
    }

    public void startFerrisRide(){
        Debug.Log("Starting Ferris");
        player.SetActive(false);
        onFerris = true;
        startPosition = player.transform.position;
        startRotation = player.transform.rotation;
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<FPSControllerScript>().enabled = false;
        // Debug.Log(ferrisPosition.position);
        Vector3 pos = new Vector3(ferrisPosition.position.x-4.95f,ferrisPosition.position.y-10.3f,ferrisPosition.position.z+7.44f);
        // Vector3 rot = player.transform.rotation.eulerAngles;
        // player.transform.eulerAngles = new Vector3(rot.x,rot.y,180);
        player.transform.position = pos;
        // player.transform.SetParent(bone13);
        // Debug.Log(startRotation.eulerAngles);
        // Debug.Log(player.transform.eulerAngles);
        player.SetActive(true);
        ferris.GetComponent<FerrisWheelRotate>().enabled = true;
        ferris.GetComponent<FerrisWheelRotate>().startGondolas();
    }

    public void endFerrisRide(){
        Debug.Log("Ending Ferris");
        player.SetActive(false);
        player.transform.SetParent(null);
        player.transform.position = startPosition;
        player.transform.rotation = startRotation;
        player.GetComponent<CharacterController>().enabled = true;
        player.GetComponent<FPSControllerScript>().enabled = true;
        // Debug.Log(ferrisPosition.position);
        // resetCamera();
        player.SetActive(true);
        ferris.GetComponent<FerrisWheelRotate>().enabled = false;
        onFerris = false;
        enableGazeControl(true);
    }

    public void startCoasterRide(){
        Debug.Log("Starting Coaster");
        inCart = true;
        cartStartPos = cartPosition.position;
        cartStartRotation = cartPosition.rotation;
        startPosition = player.transform.position;
        startRotation = player.transform.rotation;
        player.SetActive(false);
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<FPSControllerScript>().enabled = false;
        Debug.Log(cartPosition.position);
        Vector3 pos = new Vector3(cartPosition.position.x-1.0f,cartPosition.position.y+6.0f,cartPosition.position.z+1.0f);
        player.transform.position = pos;
        player.transform.rotation = cartPosition.rotation;
        player.transform.SetParent(cart.transform);
        player.SetActive(true);
        cart.GetComponent<MoveCart>().enabled = true;
        cart.GetComponent<AudioSource>().enabled = true;
    }

    public void endCoasterRide(){
        // yield return new WaitForSeconds(1);
        Debug.Log("Ending Coaster");
        player.SetActive(false);
        player.transform.SetParent(null);
        player.transform.position = startPosition;
        player.transform.rotation = startRotation;
        player.GetComponent<CharacterController>().enabled = true;
        player.GetComponent<FPSControllerScript>().enabled = true;
        player.SetActive(true);
        inCart = false;
        cart.GetComponent<MoveCart>().enabled = false;
        cart.GetComponent<AudioSource>().enabled = false;
        cartPosition.position = cartStartPos;
        cartPosition.rotation = cartStartRotation;
        enableGazeControl(true);
    }

    public void moveToFerris(){
        player.SetActive(false);
        // player.transform.position = ferrisPosition;
        player.SetActive(true);
    }


    public void StartProgress ()
    {
        _isRadialFilled = false;
    }

    public bool ProgressRadialImage()
    {
        if (_isRadialFilled == false)
        {
            //advance timer
            _timer += Time.deltaTime;
            circleLoader.fillAmount = _timer / gazeDuration;

            //if timer exceeds duration, complete progress and reset
            if (_timer >= gazeDuration)
            {
                ResetProgress();
                _isRadialFilled = true;
                return true;
            }
        }
        return false;
    }

    public void ResetProgress()
    {
        _timer = 0f;
        circleLoader.fillAmount = 0f;
    }

}
