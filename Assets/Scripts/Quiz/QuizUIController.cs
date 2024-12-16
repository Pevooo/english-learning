using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizUIController : MonoBehaviour
{
    public Text elapsedTimeText;
    public Text remainingTimeText;
    public int Time;
    public Sprite FullHeart;
    public Sprite EmptyHeart;
    public Image[] Hearts;
    private int elapsedTime = 0;
    [HideInInspector]
    public int health = 3;

    void Start()
    {
        remainingTimeText.text = $"Remaining Time: {Time}";
        elapsedTimeText.text = "Elapsed Time: 0";
        StartCoroutine(StartTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartTimer() {
        while (Time > 0) {
            yield return new WaitForSeconds(1);
            
            elapsedTime++;
            Time--;
            remainingTimeText.text = $"Remaining Time: {Time}";
            elapsedTimeText.text = $"Elapsed Time: {elapsedTime}";
        }

        onTimerRunOut();
    }

    public void SetHealth(int lives) {
        health = lives;
        if (lives == 0) {
            SceneManager.LoadScene("GameOver");
        } else {
            for (int i = 0; i < 3 - lives; i++) {
                Hearts[i].sprite = EmptyHeart;
            }
        }
    }

    public void DecrementHealth() {
        SetHealth(health - 1);
    }
    void onTimerRunOut() {
        SceneManager.LoadScene("GameOver");
    }
}
