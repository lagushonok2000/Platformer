using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneStartLevel1 : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private GameObject _canvasCoins;
    [SerializeField] private GameObject _camera1;
    [SerializeField] private GameObject _camera2;

    private void Start()
    {
        _playerInput.enabled= false;
        _canvasCoins.SetActive(false);
        StartCoroutine(CutScene());
    }

    private IEnumerator CutScene()
    {
        yield return new WaitForSeconds(6);
        _camera2.SetActive(false);
        _camera1.SetActive(true);
        _canvasCoins.SetActive(true);
        _playerInput.enabled= true;
    }
}
