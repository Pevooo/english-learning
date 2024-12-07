using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizController : MonoBehaviour
{
    public TextMesh movementTutorialText;
    public float animationTime = 2f;
    void Start()
    {
        StartCoroutine(FadeIn(movementTutorialText));
    }

    
    void Update()
    {
        
    }

    public IEnumerator FadeIn(TextMesh textMesh)
    {
        Color color = textMesh.color;

        float elapsedTime = 0f;
        while (elapsedTime < animationTime)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / animationTime);
            color.a = alpha;
            textMesh.color = color;
            yield return null;
        }

        color.a = 1f;
        textMesh.color = color;
    }
}
