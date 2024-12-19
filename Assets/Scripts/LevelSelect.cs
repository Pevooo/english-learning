using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public Button AlphabetLevel;
    public Button NumbersLevel;
    public Button QuizLevel;

    // Start is called before the first frame update
    void Start()
    {
        AlphabetLevel.onClick.AddListener(() => {
            SceneManager.LoadScene("AlphabetLearn");
        });
        NumbersLevel.onClick.AddListener(() => {
            SceneManager.LoadScene("NumbersLearn");
        });
        QuizLevel.onClick.AddListener(() => {
            SceneManager.LoadScene("Quiz");
        });
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
