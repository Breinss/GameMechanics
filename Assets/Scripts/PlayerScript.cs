using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    float moveSpeed;
    Quaternion rotation;
    float rotationSpeed;
	int playerState;
	Vector3 pos;

	// Use this for initialization
	void Start () {
		playerState = 1;
        moveSpeed = 2.0f;
        rotationSpeed = 0.5f;
    }
	
	// Update is called once per frame
	void Update () {
		transform.position += pos;

		if(Input.GetKeyUp("space")){
            if (playerState == 1)
            {
                playerState = 2;
                print("PlayerState Set to 2");
            }
            else
            {
                playerState = 1;
                print("PlayerState Set to 1");
            }
            
        }

		switch (playerState) {
		case 1:
                pos.y = 0.01f;
			break;

		case 2:
                pos.y = -0.01f;
                break;
		}

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        //transform.position = Vector3.MoveTowards(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), moveSpeed * Time.deltaTime); //Not a Core Mechanic just me trying out some stuff
    }
}
