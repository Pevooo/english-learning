using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnimationHandler : MonoBehaviour
{
    public Sprite[] Sprites;
    public float AnimationSpeed = 5f;

    private int currentIndex;
    Coroutine coroutine;
    bool IsDone;
    void Start() {
        PlayAnimation();
    }
    public void PlayAnimation()
    {
        IsDone = false;
        StartCoroutine(AnimationCoroutine());
    }

    public void StopAnimation()
    {
        IsDone = true;
        StopCoroutine(AnimationCoroutine());
    }
    IEnumerator AnimationCoroutine()
    {
        yield return new WaitForSeconds(1.0f / AnimationSpeed);
        if (currentIndex >= Sprites.Length) {
            currentIndex = 0;
        }
        GetComponent<Image>().sprite = Sprites[currentIndex];
        currentIndex += 1;
        if (IsDone == false) {
            coroutine = StartCoroutine(AnimationCoroutine());
        }
    }
}