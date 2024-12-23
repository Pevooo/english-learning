using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizUIController : MonoBehaviour
{
    public int Time;
    public Sprite FullHeart;
    public Sprite EmptyHeart;
    public Image[] Hearts;
    [HideInInspector]
    public int health = 3;

    void Start()
    {
        
        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer() {
        while (Time > 0) {
            yield return new WaitForSeconds(1);
            Time--;
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
        var controller = GameObject.Find("Character").GetComponent<PlayerController>();
        controller.StartDamageEffect();
    }

    public void DecrementHealth() {
        SetHealth(health - 1);
    }
    void onTimerRunOut() {
        SceneManager.LoadScene("GameOver");
    }
}
