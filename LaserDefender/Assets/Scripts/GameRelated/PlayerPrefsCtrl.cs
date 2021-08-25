using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsCtrl : MonoBehaviour
{
    const string PLAYER_HIGHSCORE = "Player Highscore";

    public static void SetHighscore(int amount) {
        PlayerPrefs.SetInt(PLAYER_HIGHSCORE, amount);
    }

    public static int GetHighscore() {
        return PlayerPrefs.GetInt(PLAYER_HIGHSCORE);
    }
}
