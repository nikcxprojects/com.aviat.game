using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _timeSpawn;
    [SerializeField] private Reels _reels;
    [SerializeField] [Range(1, 3)] private int _maxEnemiesOnLine;


    private void Start()
    {
        StartCoroutine(Spawn());
    }
    
    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeSpawn);
            var count = Random.Range(1, _maxEnemiesOnLine + 1);
            for (var i = 0; i < count; i++)
            {
                var pos = new Vector2(DisplayManager.RightX + 1.5f, _reels.GetRandomReel().y);
                Instantiate(_prefab, pos, Quaternion.identity);
            }
        }
    }
}
