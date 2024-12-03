using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberListController : MonoBehaviour
{
    public Button NextButton;
    public Button BackButton;
    public Button AudioPlayButton;
    public Text DisplayText;
    private int currentIndex = 0;
    public AudioClip[] NumberClips;
    public Sprite[] NumberImages;
    private AudioSource audioSource;
    private Image backgroundImage;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        backgroundImage = GameObject.Find("Panel").GetComponent<Image>();

        BackButton.enabled = false;

        PlayAudio();
        SetBackground();

        NextButton.onClick.AddListener(() =>
        {
            currentIndex++;
            PlayAudio();
            SetBackground();
            if (currentIndex == NumberClips.Length - 1)
            {
                NextButton.enabled = false;
            }
            else
            {
                BackButton.enabled = true;
                NextButton.enabled = true;
            }
        });

        BackButton.onClick.AddListener(() =>
        {
            currentIndex--;
            PlayAudio();
            SetBackground();
            if (currentIndex == 0)
            {
                BackButton.enabled = false;
            }
            else
            {
                BackButton.enabled = true;
                NextButton.enabled = true;
            }
        });

        AudioPlayButton.onClick.AddListener(() => {
            PlayAudio();
        });

      
    }
    void PlayAudio(){
        audioSource.clip = NumberClips[currentIndex];
        audioSource.Play();
    }

    void SetBackground() {
        backgroundImage.sprite = NumberImages[currentIndex];
    }
}
