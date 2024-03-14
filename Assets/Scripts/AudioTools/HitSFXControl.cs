using UnityEngine;

public class HitSFXControl : MonoBehaviour
{
    public AudioClip HitSFX;
    public AudioClip DestroySFX;

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

    public void PlayHit()
    {
        audioSource.PlayOneShot(HitSFX);
    }

    public void PlayDestroy()
    {
        audioSource?.PlayOneShot(DestroySFX);
    }
}
