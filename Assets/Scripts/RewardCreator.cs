using UnityEngine;
using System.Collections;

public class RewardCreator : MonoBehaviour
{
    private float minY;
    private float maxX;
    private float maxY;
    public bool isInPlay;
    private GameObject tempTilePos;
    private LevelCreator _levelCreator;
    private GameObject _reward;
    private GameObject _player;

	// Use this for initialization
    private void Start()
    {
        _player = GameObject.Find("Player");
        _reward = GameObject.Find("reward");
        isInPlay = true;
        minY = 4f;
        maxY = 6f;
        maxX = 7.5f;
    }

    private void FixedUpdate()
    {
        if (!isInPlay)
        {
            reSpawn();
        }
        if (_reward.transform.position.x < _player.transform.position.x - maxX)
        {
            reSpawn();
        }
    }

    private void reSpawn()
    {
         tempTilePos = GetComponent<LevelCreator>().tmpTile;
         _reward.transform.position = new Vector3(tempTilePos.transform.position.x, tempTilePos.transform.position.y + (float)Random.Range(minY,maxY),tempTilePos.transform.position.z);
         isInPlay = true;
    }
}
