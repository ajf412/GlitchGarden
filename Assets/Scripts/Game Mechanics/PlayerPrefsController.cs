using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master volume";
    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;

    const string MASTER_DIFFICULTY_KEY = "master difficulty";
    const float MIN_DIFFICULTY = 5.0f;
    const float MAX_DIFFICULTY = 20.0f;

    // ___VOLUME SETTINGS___
    public static void SetMasterVolume(float volume)
    {
        if(volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            Debug.Log("Master Volume set to " + volume);
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master volume is out of range.");
        }
        
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    // ___DIFFICULTY SETTINGS___
    public static void SetMasterDifficulty(float difficulty)
    {
        if (difficulty >= MIN_DIFFICULTY && difficulty <= MAX_DIFFICULTY)
        {
            Debug.Log("Master Difficulty set to " + difficulty);
            PlayerPrefs.SetFloat(MASTER_DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Master difficulty is out of range.");
        }

    }

    public static float GetMasterDifficulty()
    {
        return PlayerPrefs.GetFloat(MASTER_DIFFICULTY_KEY)/10;
    }
}
