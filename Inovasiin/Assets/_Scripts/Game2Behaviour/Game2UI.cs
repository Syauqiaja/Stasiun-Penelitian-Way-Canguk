
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2UI : MonoBehaviour
{
    [SerializeField] PopUpDialog popUpDialog;
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject pausePanel;

    private bool isPaused = false;

    internal void ShowDialog(Sprite information)
    {
        popUpDialog.Show(information);
    }

    public void Pause(){
        isPaused = !isPaused;
        pausePanel.SetActive(isPaused);
    }

    public void BackToMenu(){
        SceneLoader.Instance.LoadScene("MainMenu");
    }

    internal void Success(Vector3 position, Sprite info)
    {
        popUpDialog.transform.position = position;
        popUpDialog.Show(info);
    }

    public void Win(){
        winPanel.SetActive(true);
        SoundSystem.Instance.Play(AudioType.Victory);
    }
}
