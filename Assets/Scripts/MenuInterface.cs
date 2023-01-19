using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInterface : AnimationInterface
{
    private SettingManager _settingManager;
    private MenuControl _menuControl;
    private void Awake()
    {
        _settingManager=GetComponentInChildren<SettingManager>();
        _settingManager.back += Back;
        _menuControl= GetComponentInChildren<MenuControl>();

        _menuControl.newGame += NewGame;
        _menuControl.setting += Setting;
        _menuControl.exit += Exit;
        _animator =GetComponent<Animator>();
        _animator.SetBool(_isMenuOpen, true);
    }
    private void Back()
    {
        _settingManager.Interactable?.Invoke(false);
        _animator.SetBool(_isSettingOpen, false);
        _animator.SetBool(_isMenuOpen, true);
    }
    public void EndBackAnimation()
    {
        _settingManager.Interactable?.Invoke(true);
    }
    public void Setting()
    {
        _animator.SetBool(_isSettingOpen, true);
        _animator.SetBool(_isMenuOpen, false);
    }

    public void NewGame()
    {
        _animator.SetBool(_isMenuOpen, false);
    }
    public void EndMenuAnimation()
    {
        if (!_animator.GetBool(_isSettingOpen))
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
    public void StartMenuAnimation()
    {
        _menuControl.Interactable?.Invoke(true);
    }
    public void Exit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPaused = true;
    }
}
