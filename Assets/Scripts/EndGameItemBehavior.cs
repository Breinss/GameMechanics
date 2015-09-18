using UnityEngine;
using System.Collections;

public class EndGameItemBehavior : MonoBehaviour
{
    private float speed;
    private RewardCreator _rewardCreator;
	// Use this for initialization
	void Start ()
	{
	    speed = 2f;
	    _rewardCreator = GameObject.Find("Main Camera").GetComponent<RewardCreator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
       transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, 0);
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            _rewardCreator.isInPlay = false;
        }

    }
}
