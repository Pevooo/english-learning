using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AlphabetHandler : MonoBehaviour
{
    public Button NextButton;
    public Button BackButton;
    public Button AudioPlayButton;
    public AudioClip[] AlphabetClips;
    public Sprite[] AlphabetImages;
    public Button NextLevelButton;
    private int currentIndex = 0;
    private AudioSource audioSource;
    private Image backgroundImage;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        backgroundImage = GameObject.Find("Panel").GetComponent<Image>();

        BackButton.enabled = false;
        PlayAudio();
        SetBackground();
        NextButton.onClick.AddListener(() => {
            currentIndex++;
            PlayAudio();
            SetBackground();
            if (currentIndex == AlphabetClips.Length - 1) {
                NextButton.enabled = false;
            } else {
                BackButton.enabled = true;
                NextButton.enabled = true;
            }
        });

        BackButton.onClick.AddListener(() => {
            currentIndex--;
            PlayAudio();
            SetBackground();
            if (currentIndex == 0) {
                BackButton.enabled = false;
            } else {
                BackButton.enabled = true;
                NextButton.enabled = true;
            }
        });

        AudioPlayButton.onClick.AddListener(() => {
            PlayAudio();
        });

        NextLevelButton.onClick.AddListener(() => {
            SceneManager.LoadScene("NumbersLearn");
        });
    }
    
    void PlayAudio() {
        audioSource.clip = AlphabetClips[currentIndex];
        audioSource.Play();
    }

    void SetBackground() {
        backgroundImage.sprite = AlphabetImages[currentIndex];
    }
}
