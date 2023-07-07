using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnClickSound : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private AudioType audioType = AudioType.ButtonClick;
    public void OnPointerClick(PointerEventData eventData)
    {
        SoundSystem.Instance.Play(audioType);
    }
}
