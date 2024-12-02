using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphabetHandler : MonoBehaviour
{
    public Button NextButton;
    public Button BackButton;
    public Button AudioPlayButton;
    public Text DisplayText;
    private int displayIndex = 0;
    private string smallAlphabet = "abcdefghijklmnopqrstuvwxyz";
    private string capitalAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public AudioClip[] clips;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {

        audioSource = GetComponent<AudioSource>();
        PlayAudio();

        DisplayText.text = getDisplayText();

        BackButton.enabled = false;

        NextButton.onClick.AddListener(() => {
            displayIndex++;
            DisplayText.text = getDisplayText();
            PlayAudio();

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
            PlayAudio();

            if (displayIndex == 0) {
                BackButton.enabled = false;
            } else {
                BackButton.enabled = true;
                NextButton.enabled = true;
            }
        });

         AudioPlayButton.onClick.AddListener(() => {
            PlayAudio();
        });
    }
    
    string getDisplayText() {
        return capitalAlphabet[displayIndex].ToString() + smallAlphabet[displayIndex].ToString();
    }
    void PlayAudio(){

        audioSource.clip = clips[displayIndex];
        audioSource.Play();
    }
}
