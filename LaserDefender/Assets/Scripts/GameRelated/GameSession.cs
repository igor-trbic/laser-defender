using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour {

    int score = 0;
    // Start is called before the first frame update
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
        Destroy(gameObject);
    }
}
