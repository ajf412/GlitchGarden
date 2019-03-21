using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject levelCompleteCanvas;
    [SerializeField] AudioClip winClip;
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
        AudioSource.PlayClipAtPoint(winClip, Camera.main.transform.position);
        levelCompleteCanvas.SetActive(true);
        yield return new WaitForSeconds(4.5f);
        // Load next scene
        SceneManager.LoadScene(scene.buildIndex + 1);
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
