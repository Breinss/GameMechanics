using UnityEngine;
using System.Collections;

public class TimeTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Time.timeScale = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("up"))
        {
            Time.timeScale = 1;
        }
    }
}
