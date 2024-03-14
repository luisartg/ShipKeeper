using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string NextSceneName;
    public LogoMusic LogoMusicPlayer;
    public ImageFadeSerial fadeoutProcess;
    public AudioSource StartEffectAudio;
    public float AudioFadeoutTime = 0.3f;
    public float WaitTimeForLoad = 3;
    public float WaitTimeForKeyPress = 3.5f;

    bool loadingGame = false;
    bool keyPressAllowed = false;

    private AudioFadeControl audioFadeControl;

    // Start is called before the first frame update
    void Start()
    {
        audioFadeControl = gameObject.AddComponent<AudioFadeControl>();
        audioFadeControl.WorkWith(StartEffectAudio, AudioFadeoutTime);
        StartCoroutine(KeyPressTimeOut());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !loadingGame && keyPressAllowed)
        {
            loadingGame = true;
            StartEffectAudio.Play();
            fadeoutProcess.enabled = true;
            audioFadeControl.StartFadeOut();
            LogoMusicPlayer.EndMusic();
            StartCoroutine(WaitFade());
        }
    }

    private IEnumerator KeyPressTimeOut()
    {
        yield return new WaitForSeconds(WaitTimeForKeyPress);
        keyPressAllowed = true;
    }

    private IEnumerator WaitFade()
    {
        yield return new WaitForSeconds(WaitTimeForLoad);
        SceneManager.LoadScene(NextSceneName);
    }
}
