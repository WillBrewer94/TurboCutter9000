using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    Vector2 lineOrigin;
    Vector2 lineTarget;
    LineRenderer line;
    bool draw = false;

	// Use this for initialization
	void Start () {
        lineOrigin = new Vector2(0, 0);
        lineTarget = new Vector2(0, 0);
        line = GetComponent<LineRenderer>();
        line.sortingLayerName = "Line";
    }

    // Update is called once per frame
    void Update () {

        //Sets origin and target for drawn line
        if(draw) {
            lineTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            line.SetPosition(0, lineOrigin);
            line.SetPosition(1, lineTarget);
        } else {
            line.SetPosition(0, new Vector2(0, 0));
            line.SetPosition(1, new Vector2(0, 0));
        }

        //Left mouse button click
        if(Input.GetMouseButtonDown(0)) {
            //Turn on drawing and grab position at click
            lineOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            draw = true;
            
        } else if(Input.GetMouseButtonUp(0)) {
            //Turn off drawing
            draw = false;

            //Checks for raycast collision
            CollisionTest(lineOrigin, lineTarget);
        }
	}

    public void CollisionTest(Vector2 origin, Vector2 target) {
        Vector2 direction = origin - target;
        RaycastHit2D hit = Physics2D.Linecast(origin, target);

        if(hit.collider != null) {
            Debug.Log("Target " + hit.collider.name + " Hit");
            SplitBullet(hit.collider.gameObject);
        } else {
            Debug.Log("No Target Hit");
        }
    }

    public void SplitBullet(GameObject bullet) {
        Vector2 dir = bullet.GetComponent<Rigidbody2D>().velocity;

        GameObject split1 = Instantiate(bullet);
        split1.transform.localScale = split1.transform.localScale / 2;
        split1.GetComponent<Rigidbody2D>().velocity = dir - new Vector2(-40, 0);

        GameObject split2 = Instantiate(bullet);
        split2.transform.localScale = split2.transform.localScale / 2;
        split2.GetComponent<Rigidbody2D>().velocity = dir - new Vector2(40, 0);

        Destroy(bullet);
    }
}
