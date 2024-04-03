using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthManager : MonoBehaviour
{
    private int _maxHealth;
    private int _currentHealth;

    public int MaxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }

    public int CurrentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = value; }
    }
    public int damage(int val) {
        CurrentHealth -= val;
        return CurrentHealth;

    }


    void Start()
    {
        MaxHealth = 10;
        CurrentHealth = MaxHealth;
    }
}
