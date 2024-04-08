using UnityEngine.UI;
using UnityEngine;
using System;

[RequireComponent(typeof(Health))]

public class HealthValueChanger : MonoBehaviour
{
    [SerializeField] private Health _health;

    public event Action Change;

    private float _damage;
    private float _heal;

    private float CurrentHealth => _health.CurrentHealth;
    private float MaxHealth => _health.MaxHealth;


    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    public void ClickDamageButton()
    {
        TakeDamage(CurrentHealth);
        Change?.Invoke();
    }

    public void ClickHealButton()
    {
        TakeHeal(CurrentHealth);
        Change?.Invoke();
    }

    private void TakeDamage(float health)
    {
        _damage = 10;
        _health.SetCurrentHealth(Mathf.Clamp(health - _damage, 0, MaxHealth));
    }

    private void TakeHeal(float health)
    {
        _heal = 10;
        _health.SetCurrentHealth(Mathf.Clamp(health + _heal, 0, MaxHealth));
    }
}