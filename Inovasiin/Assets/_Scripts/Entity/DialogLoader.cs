using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogLoader : MonoBehaviour
{
    [SerializeField] private List<EntityInformation> entityInformations;
    [HideInInspector] public Dictionary<EntityCode, EntityInformation> informationDict;
    
    private Image information;

    private void Awake() {
        informationDict = entityInformations.ToDictionary(x => x.entityCode, x => x);
        information = GetComponent<Image>();
        transform.localScale = Vector3.zero;
    }
    public EntityInformation ShowDialog(EntityCode code){
        LeanTween.scale(gameObject, Vector3.one, 0.5f).setEaseOutBack();
        information.sprite = informationDict[code].information;
        LeanTween.scale(gameObject, Vector3.zero, 0.3f).setEaseInSine().setDelay(2.5f);
        return informationDict[code];
    }
    public void GetEntitesCount(out int flora, out int fauna){
        flora = entityInformations.FindAll(t => t.entityType == EntityType.Flora).Count;
        fauna = entityInformations.FindAll(t => t.entityType == EntityType.Fauna).Count;
    }
}

[System.Serializable]
public class EntityInformation{
    public Sprite information;
    public EntityCode entityCode;
    public EntityType entityType;
}

[System.Serializable]
public enum EntityType{
    Flora, Fauna
}
