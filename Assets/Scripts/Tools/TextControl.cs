using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TextControl : MonoBehaviour
{
    public GameObject TextDisplay;
    public TextMeshProUGUI textArea;
    public float TextTimeGap = 0.1f;
    public TextAsset TextFile;

    private TextList TextData;

    private int lineQuantity = 0;
    private int currentLine = 0;
    private TextUnit currentText;

    private bool showNextLine = false;


    // Start is called before the first frame update
    void Start()
    {
        TextData = JsonUtility.FromJson<TextList>(TextFile.text);
        TextDisplay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (showNextLine)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ShowNextTextLine();
            }
        }
    }

    public void StartShowText(string TextId)
    {
        TextDisplay.SetActive(true);
        textArea.text = "";
        currentText = GetText(TextId);
        currentLine = -1;
        lineQuantity = currentText.TextLines.Length;
        ShowNextTextLine();
    }

    private IEnumerator WaitLineTimeGap()
    {
        showNextLine = false;
        yield return new WaitForSeconds(TextTimeGap);
        showNextLine = true;
    }

    public void ShowNextTextLine()
    {
        currentLine++;
        if (currentLine >= lineQuantity)
        {
            CloseText();
        }
        else
        {
            textArea.text = currentText.TextLines[currentLine];
            StartCoroutine(WaitLineTimeGap());
        }
    }

    private void CloseText()
    {
        TextDisplay.SetActive(false);
    }

    private TextUnit GetText(string id)
    {
        foreach (TextUnit unit in TextData.GameTexts)
        {
            if (unit.ID == id)
            {
                return unit;
            }
        }

        return null;
    }

    [Serializable]
    public class TextUnit
    {
        public string ID;
        public string[] TextLines;
    }

    [Serializable]
    public class TextList
    {
        public TextUnit[] GameTexts;
    }
}
