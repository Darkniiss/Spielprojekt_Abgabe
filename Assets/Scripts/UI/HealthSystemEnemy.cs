using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystemEnemy : MonoBehaviour
{
    private EnemyBehavior enemy;
    [SerializeField] private Slider healthSlider;

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
