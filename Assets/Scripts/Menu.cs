using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void btnClicked()
    {
        Time.timeScale = 1;
    }
}
