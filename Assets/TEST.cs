using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefsController.SetMasterVolume(0.4f);
        float volume = PlayerPrefsController.GetMasterVolume();

        Debug.Log("Checking...  Volume is set at " + volume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
