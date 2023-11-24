using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource backgroundMusic;

    void Start()
    {
        // Load the volume setting from PlayerPrefs (or use a default value)
        float savedVolume = PlayerPrefs.GetFloat("Volume", 0.5f);
        volumeSlider.value = savedVolume;
        UpdateVolume(savedVolume);
    }

    public void UpdateVolume(float volume)
    {
        // Update the volume of the background music and save it to PlayerPrefs
        backgroundMusic.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save(); // Save PlayerPrefs immediately
    }
}
