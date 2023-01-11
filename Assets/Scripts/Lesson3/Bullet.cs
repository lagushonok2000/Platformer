using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletDamage;

    void Start()
    {
        StartCoroutine(WaitDeath());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hp = collision.GetComponent<HP>();

        if (hp != null && collision.gameObject.layer != GlobalStringVars.LAYERPLAYER)
        {
            hp.Damage(_bulletDamage);
            Death();
        }
        else if(collision.gameObject.layer != GlobalStringVars.LAYERPLAYER && collision.gameObject.layer != GlobalStringVars.LAYERBULLET)
        {
            Death();
        }
    }

    private IEnumerator WaitDeath()
    {
        yield return new WaitForSeconds(4);

        Death();
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
