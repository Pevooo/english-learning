using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public Button AlphabetLevel;
    public Button NumbersLevel;

    // Start is called before the first frame update
    void Start()
    {
        AlphabetLevel.onClick.AddListener(() => {
            SceneManager.LoadScene("AlphabetLearn");
        });
        NumbersLevel.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("NumbersLearn");
        });
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
