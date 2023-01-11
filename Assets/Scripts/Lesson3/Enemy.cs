using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator _enemyAnimator;
    [SerializeField] private float _damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == GlobalStringVars.LAYERPLAYER)
        {
            _enemyAnimator.SetTrigger("Attack");

            collision.gameObject.GetComponent<HP>().Damage(_damage);
        }
    }
}
