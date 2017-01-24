using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour {
    public bool isDestroy = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space)) {
            Time.timeScale = 0.02f;
        } else if(Input.GetKeyUp(KeyCode.Space)) {
            Time.timeScale = 1;
        }
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        isDestroy = true;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
