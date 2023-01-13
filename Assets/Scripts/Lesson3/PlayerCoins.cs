using TMPro;
using UnityEngine;

public class PlayerCoins : MonoBehaviour
{
    [SerializeField] private Score _score;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == GlobalStringVars.LAYERCOINS)
        {
            _score.AddScore(1);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.layer == GlobalStringVars.LAYERCHEST)
        {
            _score.AddScore(3);
            Destroy(collision.gameObject);
        }
    }

}
