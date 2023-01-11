using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerShoot _playerShoot;

    private float _horizontal;
    private bool _jump;
    private bool _shoot;

    void Update()
    {
        _horizontal = Input.GetAxisRaw(GlobalStringVars.HORIZONTAL);
        _jump = Input.GetButtonDown(GlobalStringVars.JUMP);
        _shoot = Input.GetButtonDown(GlobalStringVars.FIRE);

        if(_shoot)
            _playerShoot.Shoot();

        _playerMovement.UpdateValue(_horizontal, _jump);
    }
}
