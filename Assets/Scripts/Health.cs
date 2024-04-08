using UnityEngine;

public class Health : MonoBehaviour
{
    public float MaxHealth { get; private set; } = 100;
    public float CurrentHealth { get; private set; }

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    public void SetMaxHealth(float health) => MaxHealth = health;
    public void SetCurrentHealth(float health) => CurrentHealth = health;
}
