using UnityEngine.UI;
using UnityEngine;
using System;

[RequireComponent(typeof(Health))]

public class HealthValueChanger : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _damage;
    [SerializeField] private float _heal;

    public event Action Change;

    private float CurrentHealth => _health.CurrentHealth;
    private float MaxHealth => _health.MaxHealth;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    public void TakeDamage()
    {
        _health.SetCurrentHealth(Mathf.Clamp(CurrentHealth - _damage, 0, MaxHealth));
        Change?.Invoke();
    }

    public void TakeHeal()
    {
        _health.SetCurrentHealth(Mathf.Clamp(CurrentHealth + _heal, 0, MaxHealth));
        Change?.Invoke();
    }
}