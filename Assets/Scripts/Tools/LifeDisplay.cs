using UnityEngine;
using TMPro;

public class LifeDisplay : MonoBehaviour
{
    private TextMeshProUGUI textArea;

    // Start is called before the first frame update
    void Start()
    {
        textArea = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReportLife(int lifePoints)
    {
        textArea.text = $"HP: {lifePoints}";
    }
}
