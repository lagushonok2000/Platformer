using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazards : MonoBehaviour
{
    [SerializeField] private float _damage = 5;
    private int _layerPlayer = 6;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _layerPlayer)
        {
            collision.gameObject.GetComponent<HP>().Damage(_damage);
        }
    }
}
