using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainInputController : MonoBehaviour
{
    [SerializeField] private InputAsset inputAsset;
    [SerializeField] private RectTransform crossHair;
    [SerializeField] private Button openButton;
    [SerializeField] private DialogLoader dialogLoader;
    [SerializeField] private CustomUIManager uiManager;
    private List<EntityCode> collectedEntities = new List<EntityCode>();
    private int _maxFlora, _maxFauna;
    private int _currentFlora = 0, _currentFauna = 0;
    public float cameraSensitivity = 1;
    public Vector2 moveInput{
        get{
            return inputAsset.moveInput;
        }
        set{
            inputAsset.moveInput = value;
        }
    }
    public Vector2 lookInput{
        private get{
            return inputAsset.lookInput;
        } set{
            inputAsset.lookInput = value * cameraSensitivity * Time.deltaTime;
        }
    }
    public bool isLooking{
        get{
            return inputAsset.isLooking;
        }
        set{
            inputAsset.isLooking = value;
        }
    }
    private void Start() {
        inputAsset.openButton = openButton;
        dialogLoader.GetEntitesCount(out _maxFlora, out _maxFauna);
        uiManager.floraCountText.text = _currentFlora.ToString() + "/"+_maxFlora.ToString();
        uiManager.faunaCountText.text = _currentFauna.ToString() + "/"+_maxFauna.ToString();
    }
    private void Update() {
        if(inputAsset.objectDetected != null){
            crossHair.localScale = Vector3.one;
        }else{
            crossHair.localScale = Vector3.one * 0.5f;
        }
    }
    public void Jump(){
        inputAsset.Jump();
    }

    public void OpenObject(){
        EntityInformation entityInformation = dialogLoader.ShowDialog(inputAsset.OpenObject());;
        if(!collectedEntities.Exists(t => t == entityInformation.entityCode)){
            collectedEntities.Add(entityInformation.entityCode);
            if(entityInformation.entityType == EntityType.Flora){
                _currentFlora++;
                uiManager.floraCountText.text = _currentFlora.ToString() + "/"+_maxFlora.ToString();
            }else{
                _currentFauna++;
                uiManager.faunaCountText.text = _currentFauna.ToString() + "/"+_maxFauna.ToString();
            }
            if(_currentFauna == _maxFauna && _currentFlora == _maxFlora){
                Invoke("Win", 3f);
            }
        }
    }

    public void Run(bool toggle){
        inputAsset.SetSpeed(toggle? 1.8f : 1f);
    }

    public void Win(){
        uiManager.Win();
    }
}