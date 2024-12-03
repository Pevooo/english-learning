using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Button ExitButton;
    public Button StartButton;

    // Start is called before the first frame update
    void Start()
    {
        AudioListener.volume = 1;

        StartButton.onClick.AddListener(() => {
            SceneManager.LoadScene("CharacterSelect");
        });

        ExitButton.onClick.AddListener(() => {
            #if UNITY_EDITOR
            // Exit play mode in the editor
                UnityEditor.EditorApplication.isPlaying = false;
            #else
            // Close the application
                Application.Quit();
            #endif
        });
    }
}
