using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{

   private void OnTriggerEnter2D(Collider2D col)
   {
      if (col.CompareTag("Enemy"))
      {
         Destroy(col.gameObject);
      }
   }

   private void OnCollisionEnter2D(Collision2D col)
   {
      if (col.collider.CompareTag("Player")) return;
      Destroy(gameObject);
   }
}