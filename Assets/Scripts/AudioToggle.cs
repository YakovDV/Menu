using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]

public class AudioToggle : MonoBehaviour
{
    private Toggle _toggle;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
    }

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(ToggleListener);
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(ToggleListener);
    }

    private void ToggleListener(bool isActive)
    {
        if (isActive)
        {
            AudioListener.volume = 0f;
        }
        else
        {
            AudioListener.volume = 1f;
        }
    }
}
