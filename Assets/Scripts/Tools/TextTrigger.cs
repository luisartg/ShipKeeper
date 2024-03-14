using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    public string TextIDToTrigger = "";
    private TextControl textControl;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            textControl = FindObjectOfType<TextControl>();
            textControl.StartShowText(TextIDToTrigger);
            Destroy(gameObject);
        }
    }
}
