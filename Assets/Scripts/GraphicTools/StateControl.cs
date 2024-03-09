using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateControl : MonoBehaviour
{
    public List<GameObject> StatesList = new List<GameObject>();
    
    public void ChangeTo(int stateIndex)
    {
        DeactivateAllStates();
        ActivateState(stateIndex);
    }

    public void DeactivateAllStates()
    {
        foreach (GameObject g in StatesList)
        {
            g.SetActive(false);
        }
    }

    public void DeactivateState(int stateIndex)
    {
        StatesList[stateIndex].SetActive(false);
    }

    public void ActivateState(int stateIndex)
    {
        StatesList[stateIndex].SetActive(true);
    }
}
