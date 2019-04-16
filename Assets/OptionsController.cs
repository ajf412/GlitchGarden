using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider = null;
    [SerializeField] Text volumeNumberText = null;
    [SerializeField] float defaultVolume = 0.5f;

    [SerializeField] Slider difficultySlider = null;
    [SerializeField] Text difficultyNumberText = null;
    [SerializeField] float defaultDifficulty = 10f;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetMasterDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        volumeNumberText.text = volumeSlider.value.ToString();
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player found - Start from SPLASHSCREEN");
        }

        difficultyNumberText.text = Mathf.Round(difficultySlider.value).ToString();
    }

    public void SaveAndExit()
    {
        
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetMasterDifficulty(Mathf.Round(difficultySlider.value));
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
