using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFXManager : MonoBehaviour
{
    public AudioClip axeSwing;
    public float fadeOutSpeed = 1f; // Volume level per second

    private bool stepsPlaying = false;
    private AudioFadeControl audioFadeSteps;

    [SerializeField]
    private AudioSource stepsAudio;
    [SerializeField]
    private AudioSource mainAudio;


    // Start is called before the first frame update
    void Start()
    {
        stepsAudio = GetComponent<AudioSource>();
        audioFadeSteps = gameObject.AddComponent<AudioFadeControl>();
        audioFadeSteps.WorkWith(stepsAudio, fadeOutSpeed);
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
        audioFadeSteps.StopFade();
        stepsAudio.Stop();
    }

    public void TurnOffSteps()
    {
        if (stepsPlaying)
        {
            stepsPlaying = false;
            audioFadeSteps.StartFadeOut();
        }
    }
    public void PlayAxeSwing()
    {
        mainAudio.PlayOneShot(axeSwing, 1);
    }
}
