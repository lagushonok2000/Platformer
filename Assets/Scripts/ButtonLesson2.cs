using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLesson2 : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Text _text;
    [SerializeField] private GameObject _bomb;

    private int _time = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _spriteRenderer.color = Color.red;
        StartCoroutine(Explosion());
    }


    private IEnumerator Explosion()
    {
        _text.text = _time.ToString();

        while (_time >= 0)
        {
            yield return new WaitForSeconds(1);

            _time--;
            _text.text = _time.ToString();
        }

        _text.text = "";
        _bomb.SetActive(true);

        yield return new WaitForSeconds(1);

        _bomb.SetActive(false);
    }    
}
