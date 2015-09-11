using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
    float moveSpeed;
    GameObject playerPos;
    Vector3 playerSize;
    GameObject canvas;
	Vector3 minusTen;

    // Use this for initialization
    void Start () {
        canvas = GameObject.Find("Canvas");
        moveSpeed = 3f;
        playerPos = GameObject.Find("Player");
        playerSize = playerPos.GetComponent<Renderer>().bounds.size;
		minusTen = new Vector3 (2, 2, 0);
    }

    // Update is called once per frame
    void Update () {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, playerPos.transform.position - transform.position);
		transform.position = Vector3.MoveTowards(transform.position, playerPos.transform.position - minusTen, moveSpeed * Time.deltaTime);

        if(transform.position == playerPos.transform.position)
        {
           // Application.LoadLevel(Application.loadedLevelName);
            print("We have been hit!");
        }
    }

}
