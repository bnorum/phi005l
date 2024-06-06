using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class healthManager : MonoBehaviour
{
    private int _maxHealth;
    private int _currentHealth;
    int starthp;
    public bool invincible = false;
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

    public void invincibility(int time)
    {
        StartCoroutine(Invincibility(time));
    }

    IEnumerator Invincibility(float time)
    {
        starthp = CurrentHealth;
        invincible = true;
        yield return new WaitForSeconds(time);
        invincible =false;

    }

    public GameObject healthBar;

    void Start()
    {
        MaxHealth = 10;
        CurrentHealth = MaxHealth;
        healthBar = GameObject.Find("HealthBar");
    }
    void Update()
    {
 //       healthBar.transform.localScale = new Vector2((float)CurrentHealth / MaxHealth, 1);
    }



}
