using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private TMP_Text _collectCoins;
    [SerializeField] private Score _score;

    private void Start()
    {
        _nextButton?.onClick.AddListener(NextLevel);
        _restartButton.onClick.AddListener(RestartLevel);
        _collectCoins.text = "Ты собрал монет: " + _score.CurrentScore.ToString();
    }
    private void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
