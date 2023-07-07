using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using System.Linq;

public class DataPresistenceManager : PersistentSingleton<DataPresistenceManager>
{
    [SerializeField] private string fileName = "";

    public static event Action OnAfterLoad;
    private GameData gameData = null;
    private List<IDataPresistence> dataPresistences;
    private FileDataHandler dataHandler;
    public bool IsLoaded = false;

    protected override void Awake() {
        base.Awake();
        this.dataPresistences = FindAllDataPresistences();
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
    }
    private void Start() {
        LoadData();
    }
    public void SaveData(){
        
        // TODO Saving data

        this.IsLoaded = false;
        dataHandler.Save(gameData);
    }
    public void LoadData(){
        gameData = dataHandler.Load();
        if(gameData == null){
            gameData = new GameData();
        }

        // TODO : Loading data

        OnAfterLoad?.Invoke();
        this.IsLoaded = true;
    }

    public List<IDataPresistence> FindAllDataPresistences(){
        IEnumerable<IDataPresistence> dataPresistences = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPresistence>();
        return new List<IDataPresistence>(dataPresistences);
    }

    protected override void OnApplicationQuit() {
        SaveData();
        base.OnApplicationQuit();
    }
    // private void OnApplicationFocus(bool focusStatus) {
    //     if(!focusStatus) SaveData();
    // }
    // private void OnApplicationPause(bool pauseStatus) {
    //     if(pauseStatus) SaveData();
    // }
}