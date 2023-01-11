using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    [SerializeField] private bool _isPlayer;
    [SerializeField] private Image _forwardground;

    [SerializeField] private float _maxCountHp;
    [SerializeField] private float _countHp;

    public void Damage(float damage)
    {
        _countHp -= damage;
        ChangeHP();

        if (_countHp <= 0)
            Death();
    }

    private void ChangeHP()
    {
        _forwardground.fillAmount = _countHp / _maxCountHp;
    }

    private void Death()
    {
        if (!_isPlayer)
        {
            gameObject.SetActive(false);
        }
        else
        {
            SceneManager.LoadScene(0);
            Debug.Log("Игрок умер, сцена перезапущена");
        }
    }
}
