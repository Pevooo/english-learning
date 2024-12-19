using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverController : MonoBehaviour
{
    void Start() {
        Destroy(GameObject.Find("Videoplayer"), 4.6f);
        Destroy(GameObject.Find("Screen"), 4.6f);
    }
    public void TryAgain() {
        SceneManager.LoadScene("Quiz");
    }
}
