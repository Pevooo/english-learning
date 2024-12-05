using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        audioSource.clip = UnhoverSoundEffect;
        audioSource.Play();
    }
}