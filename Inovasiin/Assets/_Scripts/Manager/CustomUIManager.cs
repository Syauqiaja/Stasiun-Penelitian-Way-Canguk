using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CustomUIManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject winPanel;
    
    public TextMeshProUGUI floraCountText;
    public TextMeshProUGUI faunaCountText;
    private bool isPaused = false;

    public void Pause(){
        if(isPaused){
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
        }else{
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void BackToMenu(){
        Time.timeScale = 1f;
        SceneLoader.Instance.LoadScene("MainMenu");
    }
    public void Restart(){
        Time.timeScale = 1f;
        SceneLoader.Instance.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadGame(int level){
        SceneLoader.Instance.LoadScene("Game "+level.ToString());
    }
    public void Win(){
        winPanel.SetActive(true);
        SoundSystem.Instance.Play(AudioType.Victory);
    }
}
