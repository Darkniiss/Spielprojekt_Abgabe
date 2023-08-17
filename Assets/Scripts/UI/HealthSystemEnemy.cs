using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystemEnemy : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;

    private EnemyBehavior enemy;

    void Start()
    {
        enemy = GetComponentInParent<EnemyBehavior>();
        healthSlider.maxValue = enemy.healthPoints;
    }

    void Update()
    {
        healthSlider.value = enemy.healthPoints;
    }
}
