using System;
using TMPro;
using UnityEngine;

public class Statue : Interactable
{
    [SerializeField] private TextMeshProUGUI statueTxt;

    private bool isPraying;
    private bool isActive = true;
    private bool isInRange;

    private void Awake()
    {
        statueTxt.enabled = false;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        isInRange = true;
        SetTxt();
        statueTxt.enabled = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        OnCollide();
        SetTxt();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isInRange = false;
        statueTxt.enabled = false;
    }

    protected override void OnCollide()
    {
        if (!isPraying || !isActive) return;
        PlayerManager.Instance.ChangeHP(PlayerManager.Instance.GetMaxHP());
        isActive = false;
    }

    public void Pray()
    {
        if (isInRange)
            isPraying = true;
    }

    private void SetTxt()
    {
        statueTxt.text = isActive ? "Press 'e' to pray" : "You can pray only once";
    }
}
