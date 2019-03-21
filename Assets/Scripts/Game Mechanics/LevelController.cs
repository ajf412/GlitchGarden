﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject levelCompleteCanvas;
    [SerializeField] AudioClip winClip;
    [SerializeField] float waitToLoad = 4.5f;
    [SerializeField] int liveAttackers = 0;  // Serialized for debugging.
    bool timerEnd = false;
    Scene scene;

    private void Start()
    {
        levelCompleteCanvas.SetActive(false);
        scene = SceneManager.GetActiveScene();
    }

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
            // Debug.Log("End Level Now");
            StartCoroutine(LevelComplete());
        }
        /*
        else
        {
            Debug.Log("Don't end yet!  Enemies: " + liveAttackers + " Game Timer: " + timerEnd);
        }
        */
    }

    IEnumerator LevelComplete()
    {
        // play win sfx
        AudioSource.PlayClipAtPoint(winClip, Camera.main.transform.position);
        // display "level complete!" canvas
        levelCompleteCanvas.SetActive(true);
        // wait for sfx
        yield return new WaitForSeconds(waitToLoad);
        // Load next scene
        FindObjectOfType<LevelLoader>().LoadNextScene();
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
