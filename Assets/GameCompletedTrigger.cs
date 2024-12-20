using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCompletedTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "Character") {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameCompletedScene");
        }
    }
}
