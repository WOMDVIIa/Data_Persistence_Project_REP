using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    [SerializeField] TMP_InputField nameField;
    [SerializeField] TMP_Text bestScoreText;

    void Start()
    {
        nameField.onEndEdit.AddListener(delegate { ChangePlayerName(); });
        nameField.text = GameManager.instance.nowPlaying;
        bestScoreText.text = "Best Score: " + GameManager.instance.bestPlayer + ": " + GameManager.instance.bestScore;
    }

    private void ChangePlayerName()
    {
        GameManager.instance.nowPlaying = nameField.text;
        //Debug.Log("DS");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
        GameManager.instance.SaveGame();
    }
}
