using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponMenuItemControl : MonoBehaviour
{
    public WeaponBaseCharacterFeature itemWeapon;
    public Button itemButton;
    public TMP_Text itemButtonName;
    public Image itemImage;
    public float itemPrice;

    void Start()
    {
        itemButtonName.text = itemWeapon.weaponName;
        itemImage.sprite = itemWeapon.weaponImage;
        itemPrice = itemWeapon.weaponPrice;
        
        itemButton.onClick.AddListener(() => ActionManager.OnWeaponSelected?.Invoke(itemWeapon));
        itemButton.onClick.AddListener(() => ActionManager.OnWeaponPurchase?.Invoke(itemPrice));
    }
}
