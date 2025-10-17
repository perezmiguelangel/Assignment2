using System;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuController : MonoBehaviour
{

    private UIDocument document;
    private Button StartButton;
    private Button ExitButton;
    private Button SettingsButton;
    private Button ResetScoreButton;
    private Button BackButton;
    private Slider VolumeSlider;

    public VisualTreeAsset mainMenuTree;
    public VisualTreeAsset settingsTree;

     
    void Awake()
    {
        document = GetComponent<UIDocument>();
        MainMenu();
    }

    void MainMenu()
    {
        unregisterCallbacks();
        document.visualTreeAsset = mainMenuTree;

        StartButton = document.rootVisualElement.Q("Start") as Button;
        StartButton.RegisterCallback<ClickEvent>(OnStartClick);

        SettingsButton = document.rootVisualElement.Q("Settings") as Button;
        SettingsButton.RegisterCallback<ClickEvent>(OnSettingsClick);

        ExitButton = document.rootVisualElement.Q("Exit") as Button;
        ExitButton.RegisterCallback<ClickEvent>(OnExitClick);
    }

    void Settings()
    {
        unregisterCallbacks();
        document.visualTreeAsset = settingsTree;
        //VolumeSlider

        VolumeSlider = document.rootVisualElement.Q("VolumeSlider") as Slider;
        VolumeSlider.RegisterValueChangedCallback(OnSliderChange);

        ResetScoreButton = document.rootVisualElement.Q("ResetScore") as Button;
        ResetScoreButton.RegisterCallback<ClickEvent>(OnResetScoreClick);

        BackButton = document.rootVisualElement.Q("Back") as Button;
        BackButton.RegisterCallback<ClickEvent>(OnBackClick);
    }

    

    private void OnStartClick(ClickEvent e)
    {
        GameController.gcInstance.LoadScene("Game");
    }

    private void OnSettingsClick(ClickEvent e)
    {
        Settings();
    }

    private void OnExitClick(ClickEvent e)
    {
        Application.Quit();
    }

    private void OnResetScoreClick(ClickEvent e)
    {
        GameController.gcInstance.ResetScore();
    }

    private void OnBackClick(ClickEvent e)
    {
        MainMenu();
    }

    private void OnSliderChange(ChangeEvent<float> e)
    {
        float vol = e.newValue / VolumeSlider.highValue;
        GameController.gcInstance.SetVolume(vol);
    }
    

    


    void unregisterCallbacks()
    {
        if (StartButton != null)
        {
            StartButton.UnregisterCallback<ClickEvent>(OnStartClick);
        }
        if (SettingsButton != null)
        {
            SettingsButton.UnregisterCallback<ClickEvent>(OnSettingsClick);
        }
        if (ExitButton != null)
        {
            ExitButton.UnregisterCallback<ClickEvent>(OnExitClick);
        }
        if (VolumeSlider != null)
        {
            VolumeSlider.UnregisterValueChangedCallback(OnSliderChange);
        }
        if (ResetScoreButton != null)
        {
            ResetScoreButton.UnregisterCallback<ClickEvent>(OnResetScoreClick);
        }
        if (BackButton != null)
        {
            BackButton.UnregisterCallback<ClickEvent>(OnBackClick);        }
        }
   
}
