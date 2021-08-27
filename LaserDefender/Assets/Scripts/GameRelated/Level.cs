// using System.Runtime.Hosting;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    [SerializeField] float delayInSeconds = 3f;
    public void LoadStartMenu() {
        SceneManager.LoadScene(0);
    }

    public void LoadGame() {
        FindObjectOfType<GameSession>().ResetGame();
        SceneManager.LoadScene("Game");
    }

    public void LoadGameOver() {
        StartCoroutine(WaitAndLoad());
    }

    IEnumerator WaitAndLoad() {
        FindObjectOfType<GameSession>().HandlePersonalHighscore();
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("GameOver");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
