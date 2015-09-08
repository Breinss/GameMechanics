using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    //float moveSpeed;
    Quaternion rotation;
    float rotationSpeed;
    int playerState;
    Vector3 pos;
    Rigidbody2D rigidBody2D;

    // Use this for initialization
    void Start() {
        // moveSpeed = 3f;

        rotationSpeed = 1f;
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown("space"))
        {
            print("Gravity Changed");
            rigidBody2D.gravityScale *= -1;

        }

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        //transform.position = Vector3.MoveTowards(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), moveSpeed * Time.deltaTime);

        

    }
}