using UnityEngine;

public class Door : MonoBehaviour
{
    public AudioSource slamdoor;
    public GameObject doorVisual;
    public Collider2D doorTrigger;
    // Start is called before the first frame update
    void Start()
    {
        doorVisual.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CloseDoor()
    {
        if (!doorVisual.activeSelf)
        {
            slamdoor.Play();
            doorVisual.SetActive(true);
        }
    }

    public void OpenDoor()
    {
        if (doorVisual.activeSelf)
        {
            slamdoor.Play();
            doorVisual.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            doorTrigger.enabled = false;
            CloseDoor();
        }
    }
}
