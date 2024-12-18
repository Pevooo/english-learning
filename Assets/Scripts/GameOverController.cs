using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverController : MonoBehaviour
{
    public void TryAgain() {
        SceneManager.LoadScene("Quiz");
    }
}
