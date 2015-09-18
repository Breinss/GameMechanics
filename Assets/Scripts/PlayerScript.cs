using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    //float moveSpeed;
    Quaternion rotation;
    float rotationSpeed;
    int playerState;
	Rigidbody2D rigidBody2D;
    private bool showStartGUI;
    private bool countDownGUI;
    private float countDownTime;
    private bool startCountDown;

    // Use this for initialization
    void Start()
    {
        startCountDown = false;
        countDownGUI = false;
        showStartGUI = true;
        Time.timeScale = 0;
        // moveSpeed = 3f;
        rotationSpeed = 1f;
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (startCountDown)
        {
            
            countDownTime -= Time.deltaTime;
            
            if(countDownTime <= 0)
            {
                Application.LoadLevel(Application.loadedLevelName);
            }
        }
        if (Input.GetKeyDown("space"))
        {
            if (showStartGUI)
            {
                Time.timeScale = 1;
                showStartGUI = false;
            }
            else
            {
                //transform.position += Vector3.up;
                rigidBody2D.gravityScale *= -1; 
            }			
        }
		//transform.Translate(Vector3.right * Time.deltaTime);
		//Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        //transform.position = Vector3.MoveTowards(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), moveSpeed * Time.deltaTime);
    }
    void OnGUI()
    {
        GUI.color = Color.black;

        if (showStartGUI)
        {
            GUI.Label(new Rect(10, 10, 1000, 20), "Press Space to Start the Game! & To reverse gravity (╯°□°）╯︵ ┻━┻");
        }
        if (countDownGUI)
        {
            GUI.Label(new Rect(10, 10, 1000, 20), "Time Remaining: " + (int)countDownTime);

        }

    }

    void OnBecameInvisible()
    {
        countDownTime = 6f;
        startCountDown = true;
        countDownGUI = true;
    }

    void OnBecameVisible()
    {
        startCountDown = false;
        countDownGUI = false;
    }
}