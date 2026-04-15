using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]

public class ButtonEffects : MonoBehaviour
{
    [SerializeField] private float _scaleMultiplier;
    [SerializeField] private float _timer = 0.2f;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Button _button;
    [SerializeField] private Color _color;

    private TextMeshProUGUI _textMeshProUGUI;
    private Color _originalColor;
    private Vector3 _originalScale;

    private Coroutine _changeStats;

    private void Awake()
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        _originalColor = _textMeshProUGUI.color;
        _originalScale = _textMeshProUGUI.transform.localScale;
    }

    protected void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClicked);

        ResetVisuals();
    }

    protected void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClicked);

        ResetVisuals();
    }

    public void OnButtonClicked()
    {
        if (_button.IsActive() == false)
        {
            return;
        }

        if (_changeStats != null)
        {
            StopCoroutine(_changeStats);
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
        _textMeshProUGUI.color = _color;
        _textMeshProUGUI.transform.localScale *= _scaleMultiplier;

        yield return new WaitForSeconds(_timer);

        ResetVisuals();

        _changeStats = null;
    }

    private void ResetVisuals()
    {
        _textMeshProUGUI.color = _originalColor;
        _textMeshProUGUI.transform.localScale = _originalScale;
    }
}