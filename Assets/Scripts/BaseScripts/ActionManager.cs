using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ActionManager
{
    public static Action<WeaponBaseCharacterFeature> OnWeaponSelected;
    public static Action<float> OnWeaponPurchase;
}
