using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] int liveAttackers = 0;  // Serialized for debugging.
    bool timerEnd = false;

    public void AddAttacker()
    {
        liveAttackers++;
    }

    public void RemoveAttacker()
    {
        liveAttackers--;
        if(liveAttackers <= 0)
        {
            EndLevel();
        }
    }

    public void EndLevel()
    {
        if(timerEnd && liveAttackers <= 0)
        {
            Debug.Log("End Level Now");
        }
        /*
        else
        {
            Debug.Log("Don't end yet!  Enemies: " + liveAttackers + " Game Timer: " + timerEnd);
        }
        */
    }

    public void TimerEnd()
    {
        timerEnd = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach(AttackerSpawner spawner in spawners)
        {
            spawner.StopSpawning();
        }
    }
}
