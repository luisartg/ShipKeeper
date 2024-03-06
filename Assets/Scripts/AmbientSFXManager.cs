using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSFXManager : MonoBehaviour
{
    [SerializeField]
    public List<AudioClip> sfxList = new();
    public int maxTimeWait = 5*60;
    public int minTimeWait = 30;

    private bool audioAvailable = false;
    private int currentTimeout;
    private AudioSource ambientAudio;
    

    // Start is called before the first frame update
    void Start()
    {
        ambientAudio = GetComponent<AudioSource>();
        StartInitialWait();
    }

    private void StartInitialWait()
    {
        audioAvailable = false;
        currentTimeout = GetRandomTime();
        StartCoroutine(AudioTimeout(currentTimeout));
    }

    // Update is called once per frame
    void Update()
    {
        if (audioAvailable)
        {
            PlayAmbientSound();
        }
    }

    private void PlayAmbientSound()
    {
        int pos = UnityEngine.Random.Range(0, sfxList.Count);
        currentTimeout = GetRandomTime();
        audioAvailable = false;
        ambientAudio.clip = sfxList[pos];
        ambientAudio.Play();
        StartCoroutine(WaitForAudioToEnd());
    }

    private int GetRandomTime()
    {
        return UnityEngine.Random.Range(minTimeWait, maxTimeWait + 1);
    }

    IEnumerator WaitForAudioToEnd()
    {
        while (ambientAudio.isPlaying)
        {
            // check each n seconds, so this is not called constantly
            // most of the sounds are more than one second anyway
            yield return new WaitForSeconds(3); 
        }
        StartCoroutine(AudioTimeout(currentTimeout));
    }

    IEnumerator AudioTimeout(int seconds)
    {
        Debug.Log($"Waiting {seconds} for ambience availability");
        yield return new WaitForSeconds(seconds);
        audioAvailable = true;
    }
}
