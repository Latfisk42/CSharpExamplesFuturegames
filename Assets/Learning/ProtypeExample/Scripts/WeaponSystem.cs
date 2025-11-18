using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Learning.Prototype {
    public class WeaponSystem : MonoBehaviour{
        internal enum Weapons {
            None,
            Pistol,
            Rifle,
            RocketLauncher
        }

        public event Action<int> OnWeaponChanged;
        public event Action<int> OnAmmoChanged;

        private static Weapons currentWeapon = Weapons.Pistol;


        private static readonly Dictionary<Weapons, int> ammoDict = new() {
            { Weapons.None, 0 },
            { Weapons.Pistol, 99 },
            { Weapons.Rifle, 20 },
            { Weapons.RocketLauncher, 5 }
        };

        private Queue<Bullet> activeBullets;
        public Player player;
        public GameObject bulletPrefab;

        public void PlayerShoot() {
            if(ammoDict[currentWeapon] <= 0) {
                return;
            }
            ammoDict[currentWeapon]--;
            OnAmmoChanged?.Invoke(ammoDict[currentWeapon]);

            var go = Object.Instantiate(bulletPrefab, player.transform.position + player.transform.forward, player.transform.rotation);
            var bullet = go.GetComponent<Bullet>();

            //activeBullets.Enqueue(bullet);
        }
        public void ChangeWeapon(int weaponIndex) {
            Weapons newWeapon = (Weapons)(weaponIndex % 4);
            currentWeapon = newWeapon;
            OnWeaponChanged?.Invoke((int)currentWeapon);
            OnAmmoChanged?.Invoke(ammoDict[currentWeapon]);
        }
    }
}
