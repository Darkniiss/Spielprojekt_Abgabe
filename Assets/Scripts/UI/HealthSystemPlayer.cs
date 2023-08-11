using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystemPlayer : MonoBehaviour
{
    private PlayerController player;
    [SerializeField] private Slider healthSlider;

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
