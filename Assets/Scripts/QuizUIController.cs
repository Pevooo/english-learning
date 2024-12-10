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
    private int elapsedTime = 0;
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

    void onTimerRunOut() {
        //SceneManager.LoadScene("GameOver");
    }
}
