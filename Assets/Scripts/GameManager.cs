using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public int width;
    public int height;
    public GameObject bullet;
    public Vector2 startVelocity = new Vector2(0, -40);
    public GameObject audio;

    Vector2 lineOrigin;
    Vector2 lineTarget;
    LineRenderer line;
    bool draw = false;

    private void Awake() {
        DontDestroyOnLoad(GameObject.Find("Audio Source"));
    }

    // Use this for initialization
    void Start () {
        //Set Screen Resolution
        //Screen.fullScreen = false;
        Screen.SetResolution(600, 900, false);

        lineOrigin = new Vector2(0, 0);
        lineTarget = new Vector2(0, 0);
        line = GetComponent<LineRenderer>();
        line.sortingLayerName = "Line";

        //Find Bullet
        bullet = GameObject.Find("Bullet");

        if(bullet.tag == "Level") {
            StartCoroutine(LevelStart());
        } 
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

        if(hit.collider != null || hit.collider.tag != "Wall") {
            if(hit.collider.tag == "Start") {
                Debug.Log("Start Hit");
                StartCoroutine(LoadLevelDelay(2, "Level1"));
            }

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
        split1.GetComponent<Rigidbody2D>().velocity = bullet.GetComponent<Rigidbody2D>().velocity;
        split1.GetComponent<Rigidbody2D>().velocity = dir - new Vector2(-40, 0);

        GameObject split2 = Instantiate(bullet);
        split2.transform.localScale = split2.transform.localScale / 2;
        split2.GetComponent<Rigidbody2D>().velocity = bullet.GetComponent<Rigidbody2D>().velocity;
        split2.GetComponent<Rigidbody2D>().velocity = dir - new Vector2(40, 0);

        Destroy(bullet);
    }

    IEnumerator LevelStart() {
        yield return new WaitForSeconds(3);
        bullet.GetComponent<Rigidbody2D>().velocity = startVelocity;
    }

    IEnumerator LoadLevelDelay(int delay, string level) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(level);
    }
}
