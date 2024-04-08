using UnityEngine.UI;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Slider))]
public class SmoothlyHealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private HealthValueChanger _healthChanger;
    [SerializeField] private float _value;
    [SerializeField] private float _interpolationValue;

    private Slider _bar;
    private Coroutine _coroutine;

    private void Awake()
    {
        _bar = GetComponent<Slider>();
    }

    private void Start()
    {
        SetSliderValue();
    }

    private void OnEnable()
    {
        _healthChanger.Change += SetSliderValue;
    }

    private void OnDisable()
    {
        _healthChanger.Change -= SetSliderValue;
    }

    private float CurrentValue => _health.CurrentHealth;
    private float MaxHealth => _health.MaxHealth;

    private void SetSliderValue()
    {
        _bar.maxValue = MaxHealth;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Smoothly());
    }

    private IEnumerator Smoothly()
    {
        var wait = new WaitForSeconds(_value);

        while (_bar.value != CurrentValue)
        {
            _bar.value = Mathf.MoveTowards(_bar.value, CurrentValue, _interpolationValue);
            yield return wait;
        }
    }
}