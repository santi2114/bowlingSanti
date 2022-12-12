using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingTouch : MonoBehaviour {
	public Transform tr;
	public Transform positionMouse;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		tr.position = positionMouse.position;
		tr.rotation = positionMouse.rotation;

	}
}
