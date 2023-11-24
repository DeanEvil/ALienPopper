using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.UI;
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
        string s = nameInput.text;
        UnityEngine.Debug.Log("your name is: " + s);
        //store in persistent data
        PersistentData.Instance.SetName(s);
        SceneManager.LoadScene("FirstLevel");
    }

    public void Settings()
    {
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

