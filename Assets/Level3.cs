using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3 : MonoBehaviour {
    public GameObject enemy1, enemy2, enemy3, enemy4;
    GameObject player;

    // Use this for initialization
    void Start () {
        enemy1 = GameObject.Find("Enemy");
        enemy2 = GameObject.Find("Enemy1");
        enemy3 = GameObject.Find("Enemy2");
        enemy4 = GameObject.Find("Enemy3");
        player = GameObject.Find("Player");

        StartCoroutine(Wait());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Wait() {
        yield return new WaitForSeconds(5);

        if(!player.GetComponent<Players>().isDestroy && enemy1.GetComponent<Enemy>().isDestroy 
            && enemy2.GetComponent<Enemy>().isDestroy && enemy3.GetComponent<Enemy>().isDestroy && enemy4.GetComponent<Enemy>().isDestroy) {
            SceneManager.LoadScene("Win");
        } else {
            SceneManager.LoadScene("Level3");
        }
    }
}
