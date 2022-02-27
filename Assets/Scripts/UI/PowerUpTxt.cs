using System;
using TMPro;
using UnityEngine;

    public class PowerUpTxt : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI statueTxt;

        [SerializeField] 
        private WeaponController weaponController;
        

        private void OnTriggerStay2D(Collider2D col)
        {
            if (!col.CompareTag("Player")) return;
            if (weaponController.GetActive())
            {
                statueTxt.text = "Press Left Mouse Button";
                statueTxt.enabled = true; 
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            statueTxt.enabled = false;
        }
    }
