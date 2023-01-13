using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private GameObject _popup;
    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.gameObject.layer == GlobalStringVars.LAYERPLAYER)
        {
            _popup.SetActive(true);
            collision.GetComponent<PlayerInput>().enabled = false;
        }
    }
}
