using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour {
    public GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(Wait());
        
	}

    IEnumerator Wait() {
        yield return new WaitForSeconds(5);

        if(!player.GetComponent<Players>().isDestroy) {
            SceneManager.LoadScene("Level2");
        } else {
            SceneManager.LoadScene("Level1");
        }
    }
}
