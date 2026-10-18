using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float defaultHP = 100;
    [SerializeField] float maxHP = 0;
    [SerializeField] public AudioSource nonLethalHit;
    [SerializeField] public AudioSource lethalHit;
    [SerializeField] float timeUntilHealUp = 2;
    [SerializeField] float healAmount = 5;
    private float _hp;
    private float _healTime;

    void Awake()
    {
        if (maxHP == 0)
        {
            maxHP = defaultHP;
        }

        _hp = defaultHP;
        _healTime = timeUntilHealUp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > _healTime && gameObject.tag == "Player")
        {
            _healTime = Time.time + timeUntilHealUp;
            healDamage(healAmount);
        }
    }

    public void takeDamage(float dmg)
    {
        _hp = _hp - dmg;

        Debug.Log(_hp);

        if (_hp < 0)
        {
            Debug.Log("DEAD! Health: ");
            Debug.Log(_hp);

            if (lethalHit != null)
            {
                lethalHit.Play();
            }
            return;
        }

        if (nonLethalHit != null)
        {
            nonLethalHit.Play();
        }
    }

    public float getHP()
    {
        return _hp;
    }

    public void healDamage(float dmg)
    {
        if (_hp == maxHP)
        {
            return;
        }       

        _hp += dmg;
    }
}
