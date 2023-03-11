using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _durationMove;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameObject _destroyEffect;
    [SerializeField] private AudioClip _moveClip;
    [SerializeField] private AudioClip _explosionClip;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(Vector2.right * _speed);
    }

    public void ToNewReel(Transform newPos)
    {
        AudioManager.getInstance().PlayAudio(_moveClip);
        StopAllCoroutines();
        StartCoroutine(Move(newPos.position));
    }

    private IEnumerator Move(Vector2 newPos)
    {
        float time = 0;
        var startValue = transform.position.y;
        while (time < _durationMove)
        {
            time += Time.deltaTime;
            float t = time / _durationMove;
            t = t * t * (3f - 2f * t);
            var y = Mathf.Lerp(startValue, newPos.y, t);
            transform.position = new Vector2(transform.position.x, y);
            yield return null;
        }

        transform.position = new Vector2(transform.position.x, newPos.y);
        yield return new WaitForSeconds(1);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Enemy"))
        {
            Instantiate(_destroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.1f);
            AudioManager.getInstance().PlayAudio(_explosionClip);
            _gameManager.GameOver();
        }
    }
}
