using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopController : MonoBehaviour
{
    [SerializeField] private TopScores _scores;
    [SerializeField] private Transform _content;

    [SerializeField] private GameObject _viewPrefab;
    
    private void Start()
    {
        foreach (Transform obj in _content) Destroy(obj.gameObject);
        
        GenerateViews();
    }

    private void GenerateViews()
    {
        for (var index = 0; index < _scores.Scores.Count; index++)
        {
            var score = _scores.Scores[index];
            var scoreView = Instantiate(_viewPrefab, _content);
            scoreView.GetComponent<Text>().text = $"{index + 1}. " + _scores.Scores[index].ToString("0000");
        }
    }
}
