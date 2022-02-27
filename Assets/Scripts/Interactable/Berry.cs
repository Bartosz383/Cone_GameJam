using UnityEngine;

    public class Berry : Interactable
    {
        [SerializeField]
        private bool heals;
        
        private int addHP = 20;
        private int subtractHP = -20;
        
        protected override void OnCollide()
        {
            PlayerManager.Instance.ChangeHP(heals ? addHP : subtractHP);
            base.OnCollide();
        }
    }
