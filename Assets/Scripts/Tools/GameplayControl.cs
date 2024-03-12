using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class GameplayControl : MonoBehaviour
{
    private int reportedBrokenStuff = 0;
    private int reportedMonsters = 0;

    private int fixedStuff = 0;
    private int monstersKilled = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DoCheck()
    {
        if (fixedStuff >= reportedBrokenStuff && monstersKilled >= reportedMonsters)
        {
            FindObjectOfType<ExitControl>().ActivateExit();
        }
    }

    public void BrokenStuffReport()
    {
        reportedBrokenStuff++;
    }

    public void MonsterReport()
    {
        reportedMonsters++;
    }

    public void FixedStuffReport()
    {
        fixedStuff++;
        DoCheck();
    }

    public void MonsterKillReport()
    {
        monstersKilled++;
        DoCheck();
    }
}
