using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFadeSerial : MonoBehaviour
{
    public List<ImageFadeInfo> ImageFadeInfoList = new();
    private List<ImageFadeControl> fadeControlList = new();

    // Start is called before the first frame update
    void Start()
    {
        foreach (ImageFadeInfo info in ImageFadeInfoList)
        {
            StartCoroutine(StartFadeProcess(info));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator StartFadeProcess(ImageFadeInfo info)
    {
        yield return new WaitForSeconds(info.StartAfterTime);

        ImageFadeControl control = gameObject.AddComponent<ImageFadeControl>();
        fadeControlList.Add(control);
        control.FadeSpeed = info.FadeSpeed;
        control.ImageTarget = info.ImageTarget;
        if (info.FadeIn)
        {
            control.StartFadeIn();
        }
        else
        {
            control.StartFadeOut();
        }
    }

    [Serializable]
    public class ImageFadeInfo
    {
        public Image ImageTarget;
        public float StartAfterTime;
        public int FadeSpeed;
        public bool FadeIn;
    }
}
