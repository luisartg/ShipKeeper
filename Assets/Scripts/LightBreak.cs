using UnityEngine;

public class LightBreak : MonoBehaviour
{
    public float BreakProbability = 1;
    public AudioClip BreakSound;
    public GameObject lightSource;
    public StateControl stateControl;
    public GameObject Broke;

    private AudioSource audioSource;
    BoxCollider2D lightCollider;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = 1;
        audioSource.loop = false;
        lightCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Shipkeeper")
        {
            lightCollider.enabled = false;
            if (BreakProbability >= Random.Range(0.1f, 1f))
            {
                Broke.SetActive(true);
                audioSource.PlayOneShot(BreakSound);
                //lightSource.SetActive(false);
                stateControl.ChangeTo(0);
            }
        }
    }
}
