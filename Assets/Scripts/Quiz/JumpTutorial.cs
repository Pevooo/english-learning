using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTutorial : MonoBehaviour
{
    public QuizController controller;
    public TextMesh jumpTutorialText;
    void OnTriggerEnter2D(Collider2D other) {
        controller.StartExternalCoroutine(controller.FadeIn(jumpTutorialText));
        Destroy(gameObject);
    }
}
