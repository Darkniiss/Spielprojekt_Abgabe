using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystemPlayer : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;

    private PlayerController player;

    void Start()
    {
        player = GetComponentInParent<PlayerController>();
    }

    void Update()
    {
        healthSlider.maxValue = player.maxHealthPoints;
        healthSlider.value = player.currentHealthPoints;
    }
}
