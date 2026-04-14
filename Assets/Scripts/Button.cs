using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]

public class Button : MonoBehaviour
{
    [SerializeField] private Color _color;
    [SerializeField] private float _scaleMultiplier;
    [SerializeField] private float _timer = 0.3f;
    [SerializeField] private AudioSource _audioSource;

    private TextMeshProUGUI _textMeshProUGUI;
    private bool _isClicked = false;

    private Coroutine _changeStats;

    private void Awake()
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    public void OnButtonClicked()
    {
        if (_isClicked)
        {
            return;
        }

        if (_changeStats != null)
        {
            _changeStats = null;
        }

        if (_audioSource.isPlaying)
        {
            _audioSource.Stop();
        }

        _audioSource.Play();
        _changeStats = StartCoroutine(ChangeStats());
    }

    private IEnumerator ChangeStats()
    {
        _isClicked = true;

        Color originalColor = _textMeshProUGUI.color;
        Vector3 originalSize = _textMeshProUGUI.transform.localScale;

        _textMeshProUGUI.color = _color;
        _textMeshProUGUI.transform.localScale *= _scaleMultiplier;

        yield return new WaitForSeconds(_timer);

        _textMeshProUGUI.color = originalColor;
        _textMeshProUGUI.transform.localScale = originalSize;

        _changeStats = null;
        _isClicked = false;
    }
}