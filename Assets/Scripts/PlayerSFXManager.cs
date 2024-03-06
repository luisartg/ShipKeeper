using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFXManager : MonoBehaviour
{
    public AudioClip axeSwing;
    public float fadeOutSpeed = 1f; // Volume level per second

    private bool stepsPlaying = false;
    Coroutine stepsFadeOutCo;

    [SerializeField]
    private AudioSource stepsAudio;
    [SerializeField]
    private AudioSource mainAudio;


    // Start is called before the first frame update
    void Start()
    {
        stepsAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TurnOnSteps()
    {
        if (!stepsPlaying)
        {
            CheckForFadeOut();
            stepsAudio.volume = 1;
            stepsPlaying = true;
            stepsAudio.loop = true;
            stepsAudio.Play();
        }
    }

    private void CheckForFadeOut()
    {
        if (stepsFadeOutCo != null)
        {
            StopCoroutine(stepsFadeOutCo);
            stepsFadeOutCo = null;
            stepsAudio.Stop();
        }
    }

    public void TurnOffSteps()
    {
        if (stepsPlaying)
        {
            stepsPlaying = false;
            stepsFadeOutCo = StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeOut() 
    {
        float currentVolume;
        Debug.Log("FadeOutStart");
        while (stepsAudio.volume > 0)
        {
            currentVolume = stepsAudio.volume - (fadeOutSpeed * Time.deltaTime);
            if (currentVolume <= 0)
            {
                currentVolume = 0;
            }
            stepsAudio.volume = currentVolume;
            yield return null;
        }
        stepsAudio.Stop();
        Debug.Log("FadeOutStopped by coroutine");
    }

    public void PlayAxeSwing()
    {
        mainAudio.PlayOneShot(axeSwing, 1);
    }
}
