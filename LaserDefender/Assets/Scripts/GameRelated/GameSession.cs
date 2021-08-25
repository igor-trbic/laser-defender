using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour {

    int score = 0;

    void Awake() {
        SetUpSingleton();
    }

    private void SetUpSingleton() {
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numberGameSessions > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    public int GetScore() {
        return score;
    }

    public void AddToScore(int scoreVal) {
        score += scoreVal;
    }

    public void ResetGame() {
        HandlePersonalHighscore();
        Destroy(gameObject);
    }

    private void HandlePersonalHighscore() {
        int currHighscore = PlayerPrefsCtrl.GetHighscore();
        Debug.Log("HIGHSCORE: " + currHighscore);
        Debug.Log("CURR SCORE: " + score);
        if (currHighscore < score) {
            PlayerPrefsCtrl.SetHighscore(score);
        }
    }
}
