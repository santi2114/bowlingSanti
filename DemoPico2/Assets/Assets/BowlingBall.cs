using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pvr_UnitySDKAPI;

public class BowlingBall : MonoBehaviour
{
    public float force;
    // Use this for initialization
    public List<Vector3> pinPositions;
    public List<Quaternion> pinRotations;
    public Vector3 ballPosition;
    
    void Start()
    {
        var pins = GameObject.FindGameObjectsWithTag("Pin");
        pinPositions = new List<Vector3>();
        pinRotations = new List<Quaternion>();
        foreach (var pin in pins)
        {
            pinPositions.Add(pin.transform.position);
            pinRotations.Add(pin.transform.rotation);
        }
        
        ballPosition = GameObject.FindGameObjectWithTag("Ball").transform.position;
    }
    
    
    // Update is called once per frame
    void Update(){
        
        if (Input.GetKeyUp(KeyCode.Space))
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, force));
        if (Input.GetKeyUp(KeyCode.LeftArrow))
            GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0), ForceMode.Impulse);
        if (Input.GetKeyUp(KeyCode.RightArrow))
            GetComponent<Rigidbody>().AddForce(new Vector3(-1, 0, 0), ForceMode.Impulse);
        if (Input.GetKeyUp(KeyCode.R))
        {
            var pins = GameObject.FindGameObjectsWithTag("Pin");
            
            for (int i = 0; i < pins.Length; i++)
            {
                //collision.gameObject.transform.parent.gameObject.tag
                var pinPhysics = pins[i].GetComponent<Rigidbody>();
                pinPhysics.velocity = Vector3.zero;
                pinPhysics.position = pinPositions[i];
                pinPhysics.rotation = pinRotations[i];
                pinPhysics.velocity = Vector3.zero;
                pinPhysics.angularVelocity = Vector3.zero;
                
                var ball = GameObject.FindGameObjectWithTag("Ball");
                ball.transform.position = ballPosition;
                ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
                ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            }
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            var ball = GameObject.FindGameObjectWithTag("Ball");
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            ball.transform.position = ballPosition;
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
        
        if (Controller.UPvr_GetKey(0, Pvr_KeyCode.APP)){
            var ball = GameObject.FindGameObjectWithTag("Ball");
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            ball.transform.position = ballPosition;
        }
        switch (Controller.UPvr_GetTouchPadClick(0)){
            case TouchPadClick.No:
                break;
            case TouchPadClick.ClickUp:
				GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, force));
				break;
                
            case TouchPadClick.ClickDown:
				var pins = GameObject.FindGameObjectsWithTag("Pin");
                for (int i = 0; i < pins.Length; i++){
                    //collision.gameObject.transform.parent.gameObject.tag
                    var pinPhysics = pins[i].GetComponent<Rigidbody>();
                    pinPhysics.velocity = Vector3.zero;
                    pinPhysics.position = pinPositions[i];
                    pinPhysics.rotation = pinRotations[i];
                    pinPhysics.velocity = Vector3.zero;
                    pinPhysics.angularVelocity = Vector3.zero;
                    
                    var ball = GameObject.FindGameObjectWithTag("Ball");
                    ball.transform.position = ballPosition;
                    ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                }
                break;
            case TouchPadClick.ClickRight:
                GetComponent<Rigidbody>().AddForce(new Vector3(-1, 0, 0), ForceMode.Impulse);
                break;
            case TouchPadClick.ClickLeft:
                GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0), ForceMode.Impulse);
                break;
            default:
                break;
        }
    }

}