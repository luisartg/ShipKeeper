using UnityEngine;

public class RepairableObject : MonoBehaviour
{
    public float RepairSpeedPerSec = 1.0f;
    public float repairTimeNeeded = 3f;
    public AudioSource repairSound;
    public StateControl stateControl;
    private States currentState = States.Broken;
    private AudioFadeControl fadeControl;

    private GameplayControl gameplayControl;

    private bool playerInRange = false;
    private float currentRepair = 0;

    // Start is called before the first frame update
    void Start()
    {
        fadeControl = gameObject.AddComponent<AudioFadeControl>();
        fadeControl.WorkWith(repairSound, 1.5f);
        gameplayControl = FindObjectOfType<GameplayControl>();
        gameplayControl.BrokenStuffReport();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            if (Input.GetKey(KeyCode.E) && currentState == States.Broken)
            {
                if (!repairSound.isPlaying)
                {
                    repairSound.Play();
                }
                currentRepair += RepairSpeedPerSec * Time.deltaTime;
                if (currentRepair >= repairTimeNeeded)
                {
                    currentState = States.Repaired;
                    stateControl.ChangeTo((int)currentState);
                    repairSound.Stop();
                    gameplayControl.FixedStuffReport();
                }
            }
            else
            {
                repairSound.Stop();
            }
        }
        else
        {
            repairSound.Stop();
        }
    }

    private enum States
    {
        Broken = 0,
        Repaired = 1
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
