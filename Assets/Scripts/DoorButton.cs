using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public Door DoorTarget;

    private bool onZone = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (onZone)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                DoorTarget.OpenDoor();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            onZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            onZone = false;
        }
    }
}
