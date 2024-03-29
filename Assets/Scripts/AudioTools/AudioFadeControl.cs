using System.Collections;
using UnityEngine;

public class AudioFadeControl: MonoBehaviour
{
    public float MaxVolume {
        get { return _maxVolume; }
        set {
            _maxVolume = Mathf.Clamp01(value);
        } 
    }

    private float _maxVolume = 1;

    private AudioSource audioS;
    private float fadeSpeed;
    private Coroutine fadeProcess;

    public void WorkWith(AudioSource audio, float speed)
    {
        audioS = audio;
        fadeSpeed = speed;
    }

    IEnumerator FadeOut()
    {
        float currentVolume;
        while (audioS.volume > 0)
        {
            currentVolume = audioS.volume - (fadeSpeed * Time.deltaTime);
            if (currentVolume <= 0)
            {
                currentVolume = 0;
            }
            audioS.volume = currentVolume;
            yield return null;
        }
        audioS.Stop();
    }

    IEnumerator FadeIn()
    {
        float currentVolume;
        audioS.Play();
        while (audioS.volume < _maxVolume)
        {
            currentVolume = audioS.volume + (fadeSpeed * Time.deltaTime);
            if (currentVolume >= _maxVolume)
            {
                currentVolume = _maxVolume;
            }
            audioS.volume = currentVolume;
            yield return null;
        }        
    }

    public void StartFadeIn()
    {
        StopFade();
        fadeProcess = StartCoroutine(FadeIn());
    }
    public void StartFadeOut()
    {
        StopFade();
        fadeProcess = StartCoroutine(FadeOut());
            
    }

    public void StopFade()
    {
        if (fadeProcess != null)
        {
            StopCoroutine(fadeProcess);
        }
    }
}