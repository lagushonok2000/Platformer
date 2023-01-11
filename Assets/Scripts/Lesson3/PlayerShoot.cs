using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _pointSpawnBullet;
    [SerializeField] private float _force;
    
    public void Shoot()
    {
        var bullet = Instantiate(_bulletPrefab, _pointSpawnBullet.position, _pointSpawnBullet.rotation);

        bullet.GetComponent<Rigidbody2D>().AddForce(_pointSpawnBullet.right * _force, ForceMode2D.Impulse);
    }
}
