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
    public WeaponHolder playerWeaponHolder;

    void Start()
    {
        itemButtonName.text = itemWeapon.weaponName;
        itemImage.sprite = itemWeapon.weaponImage;
        
        itemButton.onClick.AddListener(EquipWeapon);
    }

    void EquipWeapon()
    {
        playerWeaponHolder.EquipWeapon(itemWeapon);
    }
}
