using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void StartLevel(int level){
        SceneLoader.Instance.LoadScene("Game "+level);
    }
    public void Quit(){
        Application.Quit();
    }
}
