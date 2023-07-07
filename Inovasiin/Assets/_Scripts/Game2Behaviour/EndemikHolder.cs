using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class EndemikHolder : MonoBehaviour
{
    public List<EndemicInformation> endemicInformations = new List<EndemicInformation>();    
    private List<int> collectedEndemic = new List<int>();
    public List<HabitBoundaries> habitBoundaries = new List<HabitBoundaries>();
    private Dictionary<HabitCode, Habit> habitDict;
    private Dictionary<EndemicCode, EndemicInformation> endemicDict;
    public Game2UI uiHolder;
    public CardDeck cardDeck;

    public static EntityCard CardHolded;
    public static Habit habitHovered;

    private int currentcard;

    [System.Serializable] 
    public struct HabitBoundaries{
        public Habit habit;
        public HabitCode habitCode;
    }

    private void Awake() {
        habitDict = habitBoundaries.ToDictionary(t => t.habitCode, t => t.habit);
        endemicDict = endemicInformations.ToDictionary(t => t.endemicCode, t => t);
        currentcard = endemicInformations.Count;
        StartCoroutine(FirstDraw());
    }

    IEnumerator FirstDraw(){
        for (int i = 0; i < 4; i++)
        {
            int index = UnityEngine.Random.Range(0, endemicInformations.Count);
            cardDeck.DrawCard(endemicInformations[index], endemicInformations.Count-1);
            endemicInformations.RemoveAt(index);
            yield return new WaitForSecondsRealtime(0.5f);
        }
        
    }

    public void DrawMore(){
        if(endemicInformations.Count > 0){   
            int index = UnityEngine.Random.Range(0, endemicInformations.Count);
            cardDeck.DrawCard(endemicInformations[index], endemicInformations.Count-1);
            endemicInformations.RemoveAt(index);
        }
    }

    public void Success(Vector3 position, Sprite info) {
        uiHolder.Success(position, info);
        currentcard--;
        if(currentcard == 0) uiHolder.Win();
    }

    public bool CheckMap(){
        if(habitHovered != null){
            if(habitHovered.code == CardHolded.information.habitCode){
                return true;
            }else{
                return false;
            }
        }
        return false;
    }

    public bool IsHabitTrue(Vector2 point, HabitCode code, EndemicCode endemicCode){
        RectTransform rectTransform = habitDict[code].rectTransform;
        Rect rect = rectTransform.rect;

        float leftSide = rectTransform.anchoredPosition.x - rect.width/2;
        float rightSide = rectTransform.anchoredPosition.x + rect.width/2;
        float topSide = rectTransform.anchoredPosition.y + rect.height/2;
        float botSide = rectTransform.anchoredPosition.y - rect.height/2;

        if(point.x > leftSide && point.x < rightSide && point.y > botSide && point.y < topSide){
            // habitDict[code].Success();
            uiHolder.ShowDialog(endemicDict[endemicCode].information);
            return true;
        }
        // habitDict[code].Failure();
        return false;
    }
}

[System.Serializable]
public class EndemicInformation{
    public HabitCode habitCode;
    public EndemicCode endemicCode;
    public EntityType type;
    public Sprite entitySprite;
    public Sprite information;
}

[System.Serializable]
public enum EndemicCode{
    Gajah,
    Harimau,
    Badak,
    BungaBangkaiJangkung,
    BungaBangkaiRaksasa,
    MacanKumbang,
    BantengJawa,
    ElangJawa,
    Edelweis,
    CempakaPutih,
    Komodo,
    KakatuaKecilJambulKuning,
    Cendana,
    OrangUtan,
    IkanPesutMahakam,
    Bekantan,
    PohonUlin,
    AnggrekHitam,
    BurungMaleo,
    KuskusBeruang,
    BabiRusa,
    Begonia,
    KayuHitam,
    HiuBerjalanHalmahera,
    IkanKodokMaluku,
    Cengkeh,
    PohonTorem,
    PakisBinaya,
    BurungCendrawasih,
    PandanBuahMerah,
    Matoa
}

[System.Serializable]
public enum HabitCode{
    Sumatera,
    Jawa,
    NusaTenggara,
    Kalimantan,
    Sulawesi,
    Maluku,
    PulauIrianJaya,
    Bali
}
