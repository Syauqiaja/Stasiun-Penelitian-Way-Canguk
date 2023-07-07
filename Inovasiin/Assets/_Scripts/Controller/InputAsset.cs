using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[CreateAssetMenu(menuName ="InputAsset",fileName ="Default Input")]
public class InputAsset : ScriptableObject
{
    public Vector2 moveInput;
    public Vector2 lookInput;
    public float speedMultiplier{
        get{return _speedMultiplier;}
        private set{_speedMultiplier = value;}
    }
    private float _speedMultiplier = 1f;
    [HideInInspector] public bool isLooking = false;
    public GameObject objectDetected{
        get{
            return _objectDetected;
        }
        set{
            _objectDetected = value;
            if(value == null){
                openButton.interactable = false;
            }else{
                openButton.interactable = true;
            }
        }
    }
    private GameObject _objectDetected;
    public event Action onJump;
    public Button openButton;


    public Vector3 GetMoveAxis(){
        return new Vector3(moveInput.x, 0f, moveInput.y) * speedMultiplier;
    }
    public void Jump(){
        onJump?.Invoke();
    }

    public EntityCode OpenObject(){
        return objectDetected.GetComponent<EntityTrigger>().entityCode;
    }
    public void SetSpeed(float speedMultiplier){
        this.speedMultiplier = speedMultiplier;
    }
}
