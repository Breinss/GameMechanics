using UnityEngine;
using System.Collections;

public class levelCreator : MonoBehaviour {

	// Use this for initialization
	private GameObject tilePos;
	private float startUpPosY;
    private const float tileWidth = 0.69f;
	private int heightLevel = 0;
	private GameObject tmpTile;


	private GameObject collectedTiles;
	private GameObject gameLayer;
	private GameObject bgLayer;

    private float gameSpeed = 2.0f;
    private float outOfBoundsX;
    private int blankCounter = 0;
    private int middleCounter = 0;
    private string lastTile = "right";

	void Start () {
		gameLayer = GameObject.Find ("GameLayer");
        bgLayer = GameObject.Find("BackgroundLayer");

		collectedTiles = GameObject.Find ("Tiles");
		for(int i = 0; i<21; i++){
			GameObject tmpg1 = Instantiate(Resources.Load("left_tile", typeof(GameObject))) as GameObject;
			tmpg1.transform.parent = collectedTiles.transform.FindChild("gLeft").transform;

			GameObject tmpg2 = Instantiate(Resources.Load("mid_tile", typeof(GameObject))) as GameObject;
			tmpg2.transform.parent = collectedTiles.transform.FindChild("gMidlle").transform;

			GameObject tmpg3 = Instantiate(Resources.Load("right_tile", typeof(GameObject))) as GameObject;
			tmpg3.transform.parent = collectedTiles.transform.FindChild("gRight").transform;

			GameObject tmpg4 = Instantiate(Resources.Load("blank_tile", typeof(GameObject))) as GameObject;
			tmpg4.transform.parent = collectedTiles.transform.FindChild("blank").transform;
		}
		collectedTiles.transform.position = new Vector2 (-60.0f, -20.0f);

		tilePos = GameObject.Find ("startTile");
		startUpPosY = tilePos.transform.position.y;
	    outOfBoundsX = tilePos.transform.position.x - 6.5f;

		fillScene ();
	}

    private void FixedUpdate()
    {
        gameLayer.transform.position = new Vector2(gameLayer.transform.position.x - gameSpeed*Time.deltaTime,0);
        bgLayer.transform.position = new Vector2(bgLayer.transform.position.x - gameSpeed/4 * Time.deltaTime, 0);

        foreach (Transform child in gameLayer.transform)
        {
            if (child.position.x < outOfBoundsX)
            {
                switch (child.gameObject.name)
                {
                    case "left_tile(Clone)":
                        child.gameObject.transform.position = collectedTiles.transform.FindChild("gLeft").transform.position;
                        child.gameObject.transform.parent = collectedTiles.transform.FindChild("gLeft").transform;
                        break;
                    case "mid_tile(Clone)":
                        child.gameObject.transform.position = collectedTiles.transform.FindChild("gMidlle").transform.position;
                        child.gameObject.transform.parent = collectedTiles.transform.FindChild("gMidlle").transform;
                        break;
                    case "right_tile(Clone)":
                        child.gameObject.transform.position = collectedTiles.transform.FindChild("gRight").transform.position;
                        child.gameObject.transform.parent = collectedTiles.transform.FindChild("gRight").transform;
                        break;
                    case "blank_tile(Clone)":
                        child.gameObject.transform.position = collectedTiles.transform.FindChild("blank").transform.position;
                        child.gameObject.transform.parent = collectedTiles.transform.FindChild("blank").transform;
                        break;
                    default:
                        Destroy(child.gameObject);
                        break;
                }
            }
        }


        if (gameLayer.transform.childCount < 25)spawnTile();
        



    }

	private void fillScene(){
		for(int i = 0; i < 10; i++){
			setTile("mid");
		}
		setTile ("right");
	}
	
	public void setTile(string type){
		switch (type) {
		case "left":
			tmpTile = collectedTiles.transform.FindChild("gLeft").transform.GetChild(0).gameObject;
			break;
		case "mid":
			tmpTile = collectedTiles.transform.FindChild("gMidlle").transform.GetChild(0).gameObject;
			break;
		case "right":
			tmpTile = collectedTiles.transform.FindChild("gRight").transform.GetChild(0).gameObject;
			break;
		case "blank":
			tmpTile = collectedTiles.transform.FindChild("blank").transform.GetChild(0).gameObject;
			break;
		}
        tmpTile.transform.parent = gameLayer.transform;
        tmpTile.transform.position = new Vector2(tilePos.transform.position.x + (tileWidth), startUpPosY + (heightLevel * tileWidth));

        tilePos = tmpTile;
	    lastTile = type;
	}

    private void spawnTile()
    {
        if (blankCounter > 0)
        {
            setTile("blank");
            blankCounter--;
            return;
        }
        if (middleCounter > 0)
        {
            setTile("mid");
            middleCounter--;
            return;
        }
        if (lastTile == "blank")
        {
            changeHeight();
            setTile("left");
            middleCounter = (int) Random.Range(1, 8);
        }
        else if (lastTile == "right")
        {
            blankCounter = (int) Random.Range(2, 4);
        }
        else if (lastTile == "mid")
        {
            setTile("right");
        }
    }

    private void changeHeight()
    {
        int newHeightLevel = (int) Random.Range(0, 4);
        if (newHeightLevel < heightLevel) heightLevel--;
        else if (newHeightLevel > heightLevel) heightLevel++;

    }
}
