using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardDeck : MonoBehaviour
{
    public int cardLeft = 0;
    public TextMeshProUGUI countText;
    public RectTransform rectTransform;
    public EntityCard cardPrefab;
    public List<RectTransform> placeholders = new List<RectTransform>();
    public EndemikHolder endemikHolder;
    
    public void DrawCard(EndemicInformation information, int cardcount){
        countText.text = "Sisa \n"+cardcount.ToString();

        EntityCard drawed = Instantiate(cardPrefab, transform.position, Quaternion.identity, transform.parent);
        drawed.rectTransform.anchoredPosition = this.rectTransform.anchoredPosition;
        drawed.information = information;
        drawed.holder = endemikHolder;
        foreach (RectTransform placeholder in placeholders)
        {
            if(!placeholder.gameObject.activeInHierarchy){
                placeholder.gameObject.SetActive(true);
                drawed.placeholder = placeholder;
                drawed.gameObject.SetActive(true);
                return;
            }
        }
    }
}
