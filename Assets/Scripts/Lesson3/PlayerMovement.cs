using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerRigidbody;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private SpriteRenderer _playerSprite;
    [SerializeField] private Collider2D _playerCollider;
    [SerializeField] private Transform _bulletSpawnPoint;

    [SerializeField] private float _jumpDistanceGround;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _gravity;

    private bool _isGround;

    public void UpdateValue(float directionMove, bool isJump)
    {
        UpdateGravity();
        if (isJump)
        {
            CheckGround();
            
            if(_isGround)
            {
                Jump();
            }
        }

        if(!Mathf.Approximately(directionMove, 0))
        {
            Move(directionMove);
        }
        
        if(Mathf.Approximately(_playerRigidbody.velocity.x, 0))
        {
            _playerAnimator.SetBool("Idle", true);
            _playerAnimator.SetBool("Run", false);
        }
    }

    private void UpdateGravity()
    {
        var newVelocity = new Vector2(_playerRigidbody.velocity.x, _playerRigidbody.velocity.y - _gravity);
        _playerRigidbody.velocity = newVelocity;
    }

    private void CheckGround()
    {
        _isGround = Physics2D.Raycast(transform.position, Vector2.down, _jumpDistanceGround);

        if (_isGround)
            _playerAnimator.SetTrigger("Jump");
    }

    private void Move(float directionMove)
    {
        var current = _bulletSpawnPoint.rotation;

        if (directionMove > 0)
        {
            _bulletSpawnPoint.rotation = Quaternion.Euler(current.x, 0, current.z);
            _playerSprite.flipX = false;
        }
        else if (directionMove < 0)
        {
            _bulletSpawnPoint.rotation = Quaternion.Euler(current.x, 180, current.z);
            _playerSprite.flipX = true;
        }


        ContactPoint2D[] contacts = new ContactPoint2D[10];
        int count = _playerCollider.GetContacts(contacts);
        bool isWall = false;
 
        foreach(var contact in contacts)
        {
            if(Mathf.Approximately(contact.normal.x, -1) && directionMove > 0)
            {
                isWall = true;
            }

            if (Mathf.Approximately(contact.normal.x, 1) && directionMove < 0)
            {
                isWall = true;
            }
        }

        if(!isWall)
        {
            Vector2 newVelocity = new Vector2(directionMove * _speed, _playerRigidbody.velocity.y);
            _playerRigidbody.velocity = newVelocity;
        }

        _playerAnimator.SetBool("Idle", false);
        _playerAnimator.SetBool("Run", true);
    }

    private void Jump()
    {
        _playerRigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}
