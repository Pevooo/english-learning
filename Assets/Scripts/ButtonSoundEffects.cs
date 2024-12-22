using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class ButtonSoundEffects : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    AudioSource audioSource;
    public AudioClip HoverSoundEffect;
    public AudioClip UnhoverSoundEffect;
    void Start() {
        var source = GetComponent<AudioSource>();
        if (source == null) {
            gameObject.AddComponent<AudioSource>();
        }
        audioSource = GetComponent<AudioSource>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.clip = HoverSoundEffect;
        audioSource.Play();
        StartCoroutine(ScaleToTarget(new Vector3(1.3f, 1.3f, 1)));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        audioSource.clip = UnhoverSoundEffect;
        audioSource.Play();
        StartCoroutine(ScaleToTarget(new Vector3(1, 1, 1)));
    }

    public IEnumerator ScaleToTarget(Vector3 targetScale)
    {
        Vector3 initialScale = transform.localScale;
        float elapsedTime = 0f;

        while (elapsedTime < 0.25f)
        {
            // Lerp between initial scale and target scale
            transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / 0.25f);
            elapsedTime += Time.deltaTime;
            yield return null; // Wait until next frame
        }

        // Ensure it reaches the final target scale
        transform.localScale = targetScale;
    }
}