using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	int playerState;
	Vector3 pos;
	// Use this for initialization
	void Start () {
		playerState = 1;
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
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
    }
}
