using UnityEngine;

namespace Weapons
{
    public class PlayerWeapon : WeaponBase
    {
        protected override void Update()
        {
            base.Update();
            if (Input.GetKeyDown(KeyCode.Space)) HandleFire();
        }
    }
}