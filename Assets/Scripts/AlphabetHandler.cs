using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphabetHandler : MonoBehaviour
{
    public Button NextButton;
    public Button BackButton;
    public Text DisplayText;
    private int displayIndex = 0;
    private string smallAlphabet = "abcdefghijklmnopqrstuvwxyz";
    private string capitalAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    // Start is called before the first frame update
    void Start()
    {
        DisplayText.text = getDisplayText();

        BackButton.enabled = false;

        NextButton.onClick.AddListener(() => {
            displayIndex++;
            DisplayText.text = getDisplayText();

            if (displayIndex == smallAlphabet.Length - 1) {
                NextButton.enabled = false;
            } else {
                BackButton.enabled = true;
                NextButton.enabled = true;
            }
        });

        BackButton.onClick.AddListener(() => {
            displayIndex--;
            DisplayText.text = getDisplayText();

            if (displayIndex == 0) {
                BackButton.enabled = false;
            } else {
                BackButton.enabled = true;
                NextButton.enabled = true;
            }
        });
    }
    
    string getDisplayText() {
        return capitalAlphabet[displayIndex].ToString() + smallAlphabet[displayIndex].ToString();
    }
}
