using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LearningLevelController : MonoBehaviour
{
    public Button NextButton;
    public Button BackButton;
    public Button AudioPlayButton;
    public Button NextLevelButton;
    public AudioClip[] AudioClips;
    public Sprite[] Sprites;
    public string NextScene;
    private AudioSource audioSource;
    private Image backgroundImage;
    private int currentIndex = 0;
    void Start()
    {
        Destroy(GameObject.Find("BackgroundMusic"));
        audioSource = GetComponent<AudioSource>();
        backgroundImage = GameObject.Find("Panel").GetComponent<Image>();

        BackButton.enabled = false;

        PlayAudio();
        SetBackground();

        NextButton.onClick.AddListener(OnNext);

        BackButton.onClick.AddListener(OnBack);

        NextLevelButton.onClick.AddListener(OnNextLevel);

        AudioPlayButton.onClick.AddListener(PlayAudio);
    }
    void PlayAudio() {
        audioSource.clip = AudioClips[currentIndex];
        audioSource.Play();
    }

    void SetBackground() {
        backgroundImage.sprite = Sprites[currentIndex];
    }

    void OnNext() {
        currentIndex++;
        PlayAudio();
        SetBackground();
        if (currentIndex == AudioClips.Length - 1)
        {
            NextButton.enabled = false;
        }
        else
        {
            BackButton.enabled = true;
            NextButton.enabled = true;
        }
    }

    void OnBack() {
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
    }

    void OnNextLevel() {
        SceneManager.LoadScene(NextScene);
    }
}
