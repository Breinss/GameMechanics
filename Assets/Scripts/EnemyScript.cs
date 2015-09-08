﻿using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
    float moveSpeed;
    GameObject playerPos;
    Vector3 playerSize;
    GameObject canvas;
    // Use this for initialization
    void Start () {
        canvas = GameObject.Find("Canvas");
        moveSpeed = 3f;
        playerPos = GameObject.Find("Player");
        playerSize = playerPos.GetComponent<Renderer>().bounds.size;

    }

    // Update is called once per frame
    void Update () {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, playerPos.transform.position - transform.position);
        transform.position = Vector3.MoveTowards(transform.position, playerPos.transform.position, moveSpeed * Time.deltaTime);

        if(transform.position == playerPos.transform.position)
        {
            Time.timeScale = 0;
            canvas.SetActive(true);
            print("We have been hit!");
        }
    }

}