namespace Weapons
{
    public class EnemyWeapon : WeaponBase
    {
        protected override void Start()
        {
            base.Start();
            InvokeRepeating(nameof(HandleFire), 0, 2f);
        }

        protected override void Update() => Reload();
    }
}