using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;
[DefaultExecutionOrder(1000)]
public class UIMenuHandler : MonoBehaviour
{
    public TextMeshProUGUI playerNameInput;
    public TextMeshProUGUI bestScoreText;
    // Start is called before the first frame update
    public void StartGame()
    {
        Debug.Log(playerNameInput.text);
        // get player name from input, store it in datamanager
        DataManager.Instance.playerName = (playerNameInput.text == "") ? "Anonymous Player" : playerNameInput.text;
        // load main scene
        SceneManager.LoadScene(1);
    }
    private void Start()
    {
        // setup highscore text
        bestScoreText.text = "Best Score : " + DataManager.Instance.highScore.ToString() + " by " + DataManager.Instance.highScoreHolder;
    }
    public void Exit()
    {
        DataManager.Instance.SaveHighScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    // Update is called once per frame

}
