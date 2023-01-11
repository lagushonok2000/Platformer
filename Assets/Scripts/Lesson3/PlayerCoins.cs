using UnityEngine;

public class PlayerCoins : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == GlobalStringVars.LAYERCOINS)
        {
            Destroy(collision.gameObject);
        }
    }
}
