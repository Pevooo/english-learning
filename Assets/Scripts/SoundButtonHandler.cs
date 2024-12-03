using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundButtonHandler : MonoBehaviour
{
    public Sprite SoundOnSprite;
    public Sprite SoundOffSprite;

    // Start is called before the first frame update
    void Start() {

        if (AudioListener.volume == 0) {
            GetComponent<Image>().sprite = SoundOffSprite;
        } else {
            GetComponent<Image>().sprite = SoundOnSprite;
        }

        GetComponent<Button>().onClick.AddListener(() => {
            if (AudioListener.volume == 0) {
                AudioListener.volume = 1;
                GetComponent<Image>().sprite = SoundOnSprite;
            } else {
                AudioListener.volume = 0;
                GetComponent<Image>().sprite = SoundOffSprite;
            }
        });
    }
}
