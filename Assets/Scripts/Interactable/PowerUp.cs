using UnityEngine;

    public class PowerUp : Interactable
    {
        [SerializeField]
        private WeaponController weaponController;
        protected override void OnCollide()
        {
            weaponController.Activate();
            base.OnCollide();
        }
    }
