using UnityEngine;

public class MainAudio : MonoBehaviour
{
    private static MainAudio _mainAudio;

    private void Awake()
    {
        if (_mainAudio != null && _mainAudio != this)
        {
            Destroy(gameObject);
            return;
        }

        _mainAudio = this;
        DontDestroyOnLoad(gameObject);
    }
}