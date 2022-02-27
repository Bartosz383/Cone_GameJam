using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [Header("Damage dealt to player")]
    [SerializeField]
    int dmg = 50;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerManager.Instance.ChangeHP(-dmg);
            Destroy(gameObject);
        } 
    }
}
