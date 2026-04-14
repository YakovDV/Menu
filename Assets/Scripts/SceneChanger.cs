using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneChanger : MonoBehaviour
{
    private const string MainMenu = "SampleScene";
    private const string Authors = "authors";
    private const string AudioSettings = "AudioSettings";

    [SerializeField] private float _delay = 0.25f;

    private Coroutine _changeDelayed;

    public void OpenAuthors()
    {
        if (_changeDelayed != null)
        {
            _changeDelayed = null;
        }

        _changeDelayed = StartCoroutine(ChangeDelayed(Authors));
    }

    public void OpenMainMenu()
    {
        if (_changeDelayed != null)
        {
            _changeDelayed = null;
        }

        _changeDelayed = StartCoroutine(ChangeDelayed(MainMenu));
    }

    public void OpenAudioSettings()
    {
        if (_changeDelayed != null)
        {
            _changeDelayed = null;
        }

        _changeDelayed = StartCoroutine(ChangeDelayed(AudioSettings));
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private IEnumerator ChangeDelayed(string sceneName)
    {
        yield return new WaitForSeconds(_delay);

        SceneManager.LoadScene(sceneName);
        _changeDelayed = null;
    }
}