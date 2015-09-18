using UnityEngine;
using System.Collections;

public class ScoreHandler : MonoBehaviour
{
    private PlayerScript _playerScript;
    private float scorePerSecond;
    public float score;
    public bool showScoreAdded;
	// Use this for initialization
	void Start ()
	{
	    showScoreAdded = false;
	    score = 0f;
	    _playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
	    scorePerSecond = 1f;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    score += scorePerSecond*Time.deltaTime;
	    if (score >= 50)
	    {
	        Application.LoadLevel(Application.loadedLevel);
	    }
	}

    void OnGUI()
    {
        if (!_playerScript.showStartGUI)
        {
            GUI.color = Color.black;
            GUI.Label(new Rect(10, 10, 1000, 20), "Score: " + (int) score);
        }
    }
}
