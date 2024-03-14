using System.Collections;
using UnityEngine;

public class LogoMusic : MonoBehaviour
{
    public float WaitTimeToStart = 1f;
    public float FadeOutSpeed = 1.5f;

    private AudioSource audioS;
    private AudioFadeControl fadeControl;
    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        fadeControl = gameObject.AddComponent<AudioFadeControl>();
        fadeControl.WorkWith(audioS, FadeOutSpeed);

        StartCoroutine(StartMusicAfterTime());
    }

    private IEnumerator StartMusicAfterTime()
    {
        yield return new WaitForSeconds(WaitTimeToStart);
        audioS.Play();
    }

    public void EndMusic()
    {
        fadeControl.StartFadeOut();
    }

}
