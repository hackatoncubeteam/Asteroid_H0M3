using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] SpriteRenderer backgroundImage;


    [SerializeField] GameObject startPanel;

    [SerializeField] GameObject inGamePanel;

    [SerializeField] GameObject gameOverPanel;

    [SerializeField] GameObject pauseGamePanel;

    [SerializeField] Sprite[] sprites;


    void Awake()
    {
        if (startPanel == null)
            Debug.Log("UIController has no reference to startPanel");

        if (inGamePanel == null)
            Debug.Log("UIController has no reference to gamePanel");

        if (gameOverPanel == null)
            Debug.Log("UIController has no reference to gameOverPanel");

        if (pauseGamePanel == null)
            Debug.Log("UIController has no reference to pauseGamePanel");
    }


    void Start()
    {
        startPanel.SetActive(true);
        inGamePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        pauseGamePanel.SetActive(false);
    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        inGamePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        pauseGamePanel.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        inGamePanel.SetActive(false);
    }

    public void Pause()
    {
        inGamePanel.SetActive(!inGamePanel.activeSelf);
        pauseGamePanel.SetActive(!pauseGamePanel.activeSelf);
    }

    public void ChangeBackgroundImage(bool isOnStart)
    {
        if (isOnStart)
            backgroundImage.sprite = sprites[0];
        else
            backgroundImage.sprite = sprites[1];
    }
}
