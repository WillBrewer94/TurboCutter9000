using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level2 : MonoBehaviour {
    GameObject enemy1;
    GameObject enemy2;
    GameObject player;

	// Use this for initialization
	void Start () {
        enemy1 = GameObject.Find("Enemy");
        enemy2 = GameObject.Find("Enemy1");
        player = GameObject.Find("Player");

        StartCoroutine(Wait());
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    IEnumerator Wait() {
        yield return new WaitForSeconds(5);

        if(!player.GetComponent<Players>().isDestroy && enemy1.GetComponent<Enemy>().isDestroy && enemy2.GetComponent<Enemy>().isDestroy) {
            SceneManager.LoadScene("Level3");
        } else {
            SceneManager.LoadScene("Level2");
        }
    }
}
