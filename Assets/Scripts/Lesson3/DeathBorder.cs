using UnityEngine;

public class DeathBorder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == GlobalStringVars.LAYERPLAYER)
        {
            collision.gameObject.GetComponent<HP>().Damage(1000);
        }
    }
}
