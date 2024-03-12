using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasConfigure : MonoBehaviour
{
    private Canvas canvasRef;
    // Start is called before the first frame update
    void Start()
    {
        canvasRef = GetComponent<Canvas>();
        canvasRef.worldCamera = Camera.main;
    }
}
