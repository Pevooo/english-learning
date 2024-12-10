using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverController : MonoBehaviour
{
    public Button tryAgainButton;
    void Start()
    {
        tryAgainButton.onClick.AddListener(() => {
            SceneManager.LoadScene("Quiz");
        });
    }
}
