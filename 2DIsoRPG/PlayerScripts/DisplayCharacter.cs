using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayCharacter : MonoBehaviour
{
    TextMeshProUGUI[] texts; 
    public PlayerAttributesObject attributes;

    void Start()
    {
        texts = this.gameObject.GetComponentsInChildren<TextMeshProUGUI>();
        texts[0].text = "HP: " + attributes.currenthp;
        texts[1].text = "MP: " + attributes.currentmp;
        texts[2].text = "Strength: " + attributes.strength;
        texts[3].text = "Dex: " + attributes.dex;
    }

    // Update is called once per frame
    void Update()
    {
        texts = this.gameObject.GetComponentsInChildren<TextMeshProUGUI>();
        texts[0].text = "HP: " + attributes.currenthp;
        texts[1].text = "MP: " + attributes.currentmp;
        texts[2].text = "Strength: " + attributes.strength;
        texts[3].text = "Dex: " + attributes.dex;
    }
}
