using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SelectCharacterController : MonoBehaviour
{
    public Button HarryPotterButton;
    public Button RonWeaselyButton;
    public Button HermoineGrangerButton;
    public Text SelectedText;
    // Start is called before the first frame update
    void Start()
    {
        SelectedText.text = "";

        HarryPotterButton.onClick.AddListener(() => {
            PlayerPrefs.SetString("Character", "HarryPotter");
            SceneManager.LoadScene("LevelSelect");
        });

        RonWeaselyButton.onClick.AddListener(() => {
            PlayerPrefs.SetString("Character", "RonWeasely");
            SceneManager.LoadScene("LevelSelect");
        });

        HermoineGrangerButton.onClick.AddListener(() => {
            PlayerPrefs.SetString("Character", "HermoineGranger");
            SceneManager.LoadScene("LevelSelect");
        });
    }

    [HideInInspector]
    public void SelectCharacter(string character) {
        SelectedText.text = character;
    }
}
