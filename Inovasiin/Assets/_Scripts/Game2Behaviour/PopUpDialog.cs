using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpDialog : MonoBehaviour
{
    public Image dialogSprite;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] GameObject text;
    [SerializeField] Button nextButton;

    public void Show(Sprite sprite){
        dialogSprite.sprite = sprite;
        dialogSprite.gameObject.SetActive(true);
    }

    public void Hide(){
        dialogSprite.gameObject.SetActive(false);
    }
}
