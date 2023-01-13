using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int CurrentScore => _currentScore;

    [SerializeField] private TMP_Text _score;
    private int _currentScore = 0;

    public void AddScore(int count)
    {
        _currentScore += count;
        _score.text = _currentScore.ToString() + "/9";
    }

    private void Start()
    {
        _score.text = _currentScore.ToString() + "/9";
    }
}
