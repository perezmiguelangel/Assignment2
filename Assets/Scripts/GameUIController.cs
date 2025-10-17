using System;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class GameUIController : MonoBehaviour
{
    private UIDocument document;
    private Label scoreLabel;
    private Label waveLabel;
    private Label healthLabel;
    public PlayerController playerController;

    public VisualTreeAsset pauseTree;
    public VisualTreeAsset gameUI;

    private Button ResumeButton;
    private Button ExitButton;

    void Awake()
    {
        document = GetComponent<UIDocument>();
        GameUI();
    }


    public void PauseMenu()
    {

        Time.timeScale = 0f;

        unregisterCallbacks();
        document.visualTreeAsset = pauseTree;

        ResumeButton = document.rootVisualElement.Q("Resume") as Button;
        ResumeButton.RegisterCallback<ClickEvent>(OnResumeClick);

        ExitButton = document.rootVisualElement.Q("Exit") as Button;
        ExitButton.RegisterCallback<ClickEvent>(OnExitClick);

    }

   

    void GameUI()
    {
        unregisterCallbacks();
        document.visualTreeAsset = gameUI;

        scoreLabel = document.rootVisualElement.Q("Score") as Label;
        waveLabel = document.rootVisualElement.Q("Wave") as Label;
        healthLabel = document.rootVisualElement.Q("Health") as Label;

    }

    private void OnResumeClick(ClickEvent e)
    {
        Time.timeScale = 1f;
        GameController.gcInstance.paused = false;
        GameUI();
    }
    
    private void OnExitClick(ClickEvent e)
    {
        Time.timeScale = 1f;
        GameController.gcInstance.paused = false;
        GameController.gcInstance.LoadScene("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        UpdateHealth();
        UpdateWave();

    
    }

    void UpdateScore()
    {
        scoreLabel.text = "Score: " + GameController.gcInstance.score.ToString();
    }

    void UpdateHealth()
    {
        healthLabel.text = "Health: " + playerController.health.ToString();
    }

    void UpdateWave()
    {
        waveLabel.text = "Wave: " + GameController.gcInstance.level.ToString();
    }


    void unregisterCallbacks()
    {
        if (ResumeButton != null)
        {
            ResumeButton.UnregisterCallback<ClickEvent>(OnResumeClick);
        }
        if (ExitButton != null)
        {
            ExitButton.UnregisterCallback<ClickEvent>(OnResumeClick);
        }

    }
}
