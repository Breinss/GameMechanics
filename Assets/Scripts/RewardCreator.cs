using UnityEngine;
using System.Collections;

public class RewardCreator : MonoBehaviour {
    private GameObject collectedTiles;
    private GameObject tmpTile;
    private GameObject gameLayer;
    private float timeLeft;
    private bool endPowerUpSpawned;
    private LevelCreator levelCreator;
	// Use this for initialization
	void Start ()
	{
	    levelCreator = GameObject.Find("Main Camera").GetComponent<LevelCreator>();
	    endPowerUpSpawned = false;
	    timeLeft = 60f;
        gameLayer = GameObject.Find("GameLayer");
        collectedTiles = GameObject.Find("Rewards");


	    for (int i = 0; i < 2; i++)
	    {
	        GameObject tmpg1 = Instantiate(Resources.Load("end_game", typeof (GameObject))) as GameObject;
	        tmpg1.transform.parent = collectedTiles.transform.FindChild("EndGame").transform;
	    }
        collectedTiles.transform.position = new Vector2(-60.0f, -20.0f);
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 15 && !endPowerUpSpawned)
        {
            endPowerUpSpawned = true;
            setTile("endgame");
        }
	}
    public void setTile(string type)
    {
        switch (type)
        {
            case "endgame":
                tmpTile = collectedTiles.transform.FindChild("EndGame").transform.GetChild(0).gameObject;
                break;
        }
        tmpTile.transform.parent = gameLayer.transform;
        tmpTile.transform.position = new Vector2(levelCreator.tilePos.transform.position.x, (int)Random.Range(1, 3));
    }
}
