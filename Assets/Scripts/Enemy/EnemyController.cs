using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float tolerance;
    [SerializeField]
    private float runTime;

    private bool _isActive;
    private Transform playerTransform;
    private bool isFacingRight = false;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (_isActive)
        {
            UpdateMovement();
            CheckForFlip();
            runTime -= Time.fixedDeltaTime;
        }
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, playerTransform.position) < tolerance)
        {
            _isActive = true;
        }

        if (runTime <= 0)
        {
            StartCoroutine(Kill());
        }
    }

    private void UpdateMovement()
    {
        var position = transform.position;
        var dir = (playerTransform.position - position).normalized;
        var distance = Vector3.Distance(position, playerTransform.position);
        var distanceCovered = speed * Time.fixedDeltaTime;
        var fraction = distanceCovered / distance;
        position = Vector3.Lerp(position, playerTransform.position, fraction);
        transform.position = position;
    }
    private void CheckForFlip()
    {
        if (playerTransform.position.x > transform.position.x && !isFacingRight)
        {
            Flip();
        }
        else if (playerTransform.position.x < transform.position.x && isFacingRight)
        {
            Flip();
        }
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private IEnumerator Kill()
    {
        Debug.Log("KILL");
        var v = -2f;
        var color = spriteRenderer.color;
        spriteRenderer.color = new Color(color.r, color.g, color.b, Mathf.SmoothDamp(color.a, 0f, ref v, .5f));
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }
    public void SetSpeed(float v) => speed = v;
    
}