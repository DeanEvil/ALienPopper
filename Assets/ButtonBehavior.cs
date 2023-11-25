using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Diagnostics;

public class ButtonBehavior : MonoBehaviour
{
    [SerializeField] TMP_InputField nameInput;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoToInstructions()
    {
        SceneManager.LoadScene("InfoScreen");
    }

    public void PlayGame()
    {
        string playerName = nameInput.text;
        UnityEngine.Debug.Log("Your name is: " + playerName);

        // Store the player's name in persistent data
        PersistentData.Instance.SetName(playerName);

        // Set the player's score to 0 at the beginning of the game
        PersistentData.Instance.SetScore(0);

        SceneManager.LoadScene("Level1");
    }

    public void Settings()
    {
        SceneManager.LoadScene("SettingsScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

