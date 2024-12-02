using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Button ToggleSoundButton;
    public Button ExitButton;
    public Button StartButton;
    // Start is called before the first frame update
    void Start()
    {
        ToggleSoundButton.onClick.AddListener(() => {
            if (AudioListener.volume == 0) {
                AudioListener.volume = 1;
                ToggleSoundButton.GetComponentInChildren<Text>().text = "Toggle Sound: On";
            } else {
                AudioListener.volume = 0;
                ToggleSoundButton.GetComponentInChildren<Text>().text = "Toggle Sound: Off";
            }
        });

        StartButton.onClick.AddListener(() => {
            SceneManager.LoadScene("AlphabetLearn");
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
