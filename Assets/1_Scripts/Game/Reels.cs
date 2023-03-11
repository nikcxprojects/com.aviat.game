using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Reels : MonoBehaviour
{
    [SerializeField] private GameObject[] _reels;
    [SerializeField] private Player _player;

    [SerializeField] private int _startReelId;
    
    private int _currentReel;
    
    private void Start()
    {
        _currentReel = _startReelId;
        Invoke("MovePlayer", 0.3f);
    }

    private void MovePlayer()
    {
        _player.ToNewReel(_reels[_currentReel].transform);
    }

    public void Up()
    {
        if(_currentReel > 0) _currentReel--;
        MovePlayer();
    }

    public void Down()
    {
        if(_currentReel < _reels.Length - 1)_currentReel++;
        MovePlayer();
    }

    public Vector2 GetRandomReel()
    {
        return _reels[Random.Range(0, _reels.Length)].transform.position;
    }
}
