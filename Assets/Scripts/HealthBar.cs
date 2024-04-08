using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private HealthValueChanger _healthChanger;
    
    private Slider _bar;

    private void Awake()
    {
        _bar = GetComponent<Slider>();
    }

    private void Start()
    {
        SetSliderValues();
    }

    private void OnEnable()
    {
        _healthChanger.Change += SetSliderValues;
    }

    private void OnDisable()
    {
        _healthChanger.Change -= SetSliderValues;
    }

    private float CurrentHealth => _health.CurrentHealth;
    private float MaxHealth => _health.MaxHealth;

    private void SetSliderValues()
    {
        _bar.maxValue = MaxHealth;
        _bar.value = CurrentHealth;
    }
}