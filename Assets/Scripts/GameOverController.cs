using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverController : MonoBehaviour
{
    public Camera mainCamera;
    void Start() {
        Destroy(GameObject.Find("Videoplayer"), 4.6f);
        Destroy(GameObject.Find("Screen"), 4.6f);
        StartCoroutine(Shake(2, 150));
    }
    public void TryAgain() {
        SceneManager.LoadScene("Quiz");
    }

    private IEnumerator Shake(float duration, float magnitude)
    {
        yield return new WaitForSeconds(4.6f);
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float offsetX = UnityEngine.Random.Range(-1f, 1f) * magnitude * ((duration - elapsed) / duration);
            float offsetY = UnityEngine.Random.Range(-1f, 1f) * magnitude * ((duration - elapsed) / duration);

            mainCamera.transform.localPosition = new Vector3(offsetX, offsetY, -935);

            elapsed += Time.deltaTime;

            yield return null;
        }


    }
}
