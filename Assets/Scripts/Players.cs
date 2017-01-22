using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.E)) {
            Time.timeScale = 0.1f;
        } else if(Input.GetKeyUp(KeyCode.E)) {
            Time.timeScale = 1;
        }
		
	}
}
