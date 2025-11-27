using Learning.Prototype;
using UnityEngine;
using TMPro;
using System;
public class UIWeaponView : UIView
{
    public TextMeshProUGUI weaponText;
    public TextMeshProUGUI ammoText;

    private string currentWeapon;
    private int ammo;

  public void UpdateWeaponUI(int weaponIndex) {
      currentWeapon = ((WeaponSystem.Weapons)weaponIndex).ToString();
      weaponText.text = currentWeapon;
      ammoText.text = ammo.ToString();  }
  public void UpdateAmmoUI(int newAmmo) {
      ammo = newAmmo;
      ammoText.text = ammo.ToString();  }
}
