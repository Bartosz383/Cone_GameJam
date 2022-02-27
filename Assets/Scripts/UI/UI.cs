using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]
    private Slider hpBar;

    public void UpdateHPBar(int value)
    {
        hpBar.value = value * 100/250;
    }
}
