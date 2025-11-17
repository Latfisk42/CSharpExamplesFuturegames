using System.Collections.Generic;
using UnityEngine;

namespace Learning.Prototype {
    public class WeaponSystem : MonoBehaviour{
        internal enum Weapons {
            None,
            Pistol,
            Rifle,
            RocketLauncher
        }

        private static Weapons currentWeapon = Weapons.Pistol;


        private static readonly Dictionary<Weapons, int> ammoDict = new() {
            { Weapons.None, 0 },
            { Weapons.Pistol, 99 },
            { Weapons.Rifle, 0 },
            { Weapons.RocketLauncher, 0 }
        };

        private InputManager inputManager;
        private Queue<Bullet> activeBullets;
        public Player player;
        public GameObject bulletPrefab;
        public void PlayerShoot() {
            if(ammoDict[currentWeapon] <= 0) {
                return;
            }
            ammoDict[currentWeapon]--;
            //UIManager.RefreshUI();
            var go = Object.Instantiate(bulletPrefab, player.transform.position + player.transform.forward, player.transform.rotation);
            var bullet = go.GetComponent<Bullet>();

            //activeBullets.Enqueue(bullet);
        }
    }
}
