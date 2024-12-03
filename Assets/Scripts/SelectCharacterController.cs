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
            SceneManager.LoadScene("AlphabetLearn");
        });

        RonWeaselyButton.onClick.AddListener(() => {
            PlayerPrefs.SetString("Character", "RonWeasely");
            SceneManager.LoadScene("AlphabetLearn");
        });

        HermoineGrangerButton.onClick.AddListener(() => {
            PlayerPrefs.SetString("Character", "HermoineGranger");
            SceneManager.LoadScene("AlphabetLearn");
        });
    }

    [HideInInspector]
    public void SelectCharacter(string character) {
        SelectedText.text = character;
    }
}
