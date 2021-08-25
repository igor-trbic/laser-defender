using UnityEngine;
using TMPro;

public class HighscoreDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highscoreText;
    // void Start()
    // {
    //     highscoreText.text = PlayerPrefsCtrl.GetHighscore().ToString();
    // }
    private void Update() {
        highscoreText.text = PlayerPrefsCtrl.GetHighscore().ToString();
    }
}
