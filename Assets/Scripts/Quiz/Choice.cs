using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Spell Projectile(Clone)") {
            var questionMaker = GetComponentInParent<QuestionMaker>();

            if (questionMaker.rightAnswer == gameObject) {
                questionMaker.DestroyQuestion();
            } else {
                GameObject.Find("QuizUIController").GetComponent<QuizUIController>().DecrementHealth();
            }
        }
    }
}
