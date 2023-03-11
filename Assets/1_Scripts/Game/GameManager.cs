using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private Text _scoreText1;
    [SerializeField] private Text _scoreText2;
    [SerializeField] private TopScores _topScores;

    private int _score;

    private void Start()
    {
        _gameOverPanel.SetActive(false);
        StartCoroutine(ScoreCounter());
    }
    
    private IEnumerator ScoreCounter()
    {
        while (true)
        {
            _score++;
            _scoreText1.text = _score.ToString();
            yield return new WaitForSeconds(0.5f);
        }
    }
    
    public void GameOver()
    {
        StopAllCoroutines();
        _scoreText2.text = _score.ToString();
        _gameOverPanel.SetActive(true);
        _topScores.Scores.Add(_score);
    }
}
