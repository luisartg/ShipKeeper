using UnityEngine;
using UnityEngine.UI;

public class ImageFadeControl : MonoBehaviour
{
    public Image ImageTarget;
    public int FadeSpeed = 255; // color value per second
    private float currentColorValue;

    private FadeType fadeType = FadeType.None;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if (fadeType == FadeType.FadeOut)
        {
            ApplyFade(-FadeSpeed);
        }
        else if (fadeType == FadeType.FadeIn)
        {
            ApplyFade(FadeSpeed);
        }
    }

    private void ApplyFade(int fadeValue)
    {
        currentColorValue += ((float)fadeValue / 255) * Time.deltaTime;
        
        if (currentColorValue <= 0)
        {
            currentColorValue = 0;
            fadeType = FadeType.None;
        }
        if (currentColorValue >= 1)
        {
            currentColorValue = 1;
            fadeType = FadeType.None;
        }

        ImageTarget.color = new Color(currentColorValue, currentColorValue, currentColorValue);
    }


    public void StartFadeIn()
    {
        fadeType = FadeType.FadeIn;
        currentColorValue = 0;
    }

    public void StartFadeOut()
    {
        fadeType = FadeType.FadeOut;
        currentColorValue = 1;
    }

    private enum FadeType
    {
        FadeIn,
        FadeOut,
        None
    }
}