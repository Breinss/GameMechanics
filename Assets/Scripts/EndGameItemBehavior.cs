using UnityEngine;
using System.Collections;

public class EndGameItemBehavior : MonoBehaviour
{
    private float speed;
    private RewardCreator _rewardCreator;
    private PlayerScript _playerScript;
    private LevelCreator _levelCreator;
    private float ammountOfTime;
	// Use this for initialization
	void Start ()
	{
	    _playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
	    ammountOfTime = 5f;
	    speed = 2f;
	    _rewardCreator = GameObject.Find("Main Camera").GetComponent<RewardCreator>();
	    _levelCreator = GameObject.Find("Main Camera").GetComponent<LevelCreator>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
       transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, 0);
	}

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            _rewardCreator.isInPlay = false;
            StartCoroutine(SlowDown());
        }

    }
    IEnumerator SlowDown()
    {
        _playerScript.rigidBody2D.gravityScale = 0.25f;
        _levelCreator.gameSpeed = 0.5f;
        speed = 0.5f;
        yield return new WaitForSeconds(5);
        _playerScript.rigidBody2D.gravityScale = 0.5f;
        _levelCreator.gameSpeed = 2f;
        speed = 2f;
    }

}
