using TMPro;
using UnityEngine;

public class ExitMessage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WriteExit()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "Exit door is open...";
    }
}
