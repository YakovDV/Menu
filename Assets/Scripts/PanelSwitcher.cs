using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Button))]

public class PanelSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _currentPanel;
    [SerializeField] private GameObject _targetPanel;

    private Button _button;

    public void Awake()
    {
        _button = GetComponent<Button>();
    }

    protected void OnEnable()
    {
        _button.onClick.AddListener(SwitchPanel);
    }

    protected void OnDisable()
    {
        _button.onClick.RemoveListener(SwitchPanel);
    }

    private void SwitchPanel()
    {
        if (_targetPanel == null)
            return;

        if (_currentPanel != null)
            _currentPanel.SetActive(false);

        _targetPanel.SetActive(true);
    }
}