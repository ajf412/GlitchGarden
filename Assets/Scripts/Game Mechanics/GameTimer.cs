using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level timer in SECONDS")][SerializeField] float levelTime = 10;
    bool triggeredLevelFinished = false;

    // Update is called once per frame
    void Update()
    {
        if (triggeredLevelFinished) { return; }  // keeps the rest of the code from running if timer is already over.

        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFinished)
        {
            // Debug.Log("Level Timer Expired!");
            FindObjectOfType<LevelController>().TimerEnd();
            triggeredLevelFinished = true;
        }
    }
}
