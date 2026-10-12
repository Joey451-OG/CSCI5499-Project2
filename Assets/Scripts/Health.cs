using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float defaultHP = 100;
    [SerializeField] float maxHP = 0;
    [SerializeField] public AudioSource nonLethalHit;
    [SerializeField] public AudioSource lethalHit;

    private float _hp;

    void Awake()
    {

       if (maxHP == 0)
        {
            maxHP = defaultHP;
        }
        _hp = defaultHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(float dmg)
    {
        _hp = _hp - dmg;

        Debug.Log(_hp);

        if (_hp < 0)
        {
            Debug.Log("DEAD! Health: ");
            Debug.Log(_hp);

            lethalHit.Play();
            return;
        }

        nonLethalHit.Play();
    }

    public float getHP()
    {
        return _hp;
    }

    public void healDamage(float dmg)
    {
        _hp += dmg;
    }
}
