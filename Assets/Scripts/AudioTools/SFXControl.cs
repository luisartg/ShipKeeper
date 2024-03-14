using System.Collections.Generic;
using UnityEngine;

public class SFXControl : MonoBehaviour
{
    public List<AudioClip> SFXList = new();

    [SerializeField]
    private float maxVolume = 0.5f;

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.volume = maxVolume;
    }

    public void PlaySound(int sfxIndex)
    {
        audioSource.PlayOneShot(SFXList[sfxIndex]);
    }
}
