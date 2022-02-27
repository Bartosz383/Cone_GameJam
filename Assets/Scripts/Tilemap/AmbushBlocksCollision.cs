using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AmbushBlocksCollision : Interactable
{
    //dodaj referencję do Tilemap, żeby wyciągnąć z niej kolor i kanał alfa
    Tilemap tilemap;

    private bool isToutching = false;


    private void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    private void FixedUpdate()
    {
        isToutching = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        isToutching = true;
        StartCoroutine(SetAlpha(0.5f));
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        if (isToutching) return;
        var color = tilemap.color;
        tilemap.color = new Color(color.r, color.g, color.b, 1f);
        Debug.Log("wyjście");
        //ustaw kanał alfa na 1
    }

    protected override void OnCollide()
    {
      
        //ustaw kanał alfa na np. .3
    }

      
    private IEnumerator SetAlpha(float alpha)
    {
        var v = 0f;
        var color = tilemap.color;
        if (alpha > color.a)
        {
            v = 0.2f;
        }
        else if (alpha < color.a)
        {
            v = -0.2f;
        }
       // while(color.a != alpha)
        //{
            Debug.Log(color.a);
            tilemap.color = new Color(color.r, color.g, color.b, Mathf.SmoothDamp(color.a, alpha, ref v, .25f));
            yield return null;
        //}
               
    }

}
