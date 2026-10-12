using System;
using StarterAssets;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunFire : MonoBehaviour
{

    [SerializeField] AudioSource gunFire;
    [SerializeField] Transform rifleTransform;
    [SerializeField] float fireRateInSeconds;
    [SerializeField] float headShotDamage = 100;
    [SerializeField] float bodyShotDamage = 50;

#if ENABLE_INPUT_SYSTEM
        private PlayerInput _playerInput;
#endif
    private StarterAssetsInputs _input;
    private float _nextFire;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        _playerInput = GetComponent<PlayerInput>();
        _nextFire = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(_input.isFiring);

        // Gun looks at camera
        Vector3 viewPointCenter = new Vector3(0.5f, 0.5f, 10f);
        Vector3 worldPointCenter = Camera.main.ViewportToWorldPoint(viewPointCenter);
        rifleTransform.LookAt(worldPointCenter);


        // Gun firing
        if (_input.isFiring && Time.time > _nextFire)
        {
            _nextFire = Time.time + fireRateInSeconds;
            // Create a vector at the center of our camera's viewport
            Vector3 rayOrigin = Camera.main.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, 0.0f));

            // Declare a raycast hit to store information about what our raycast has hit
            RaycastHit hit;

            // Check if our raycast has hit anything
            if (Physics.Raycast(rayOrigin, Camera.main.transform.forward, out hit))
            {
                SkeletonController skele = hit.collider.GetComponent<SkeletonController>();
                PumpkinController pumpk = hit.collider.GetComponent<PumpkinController>();

                if (skele != null)
                {
                    float damage = hit.collider is SphereCollider ? headShotDamage : bodyShotDamage;
                    skele.takeDamage(damage);
                }

                if (pumpk != null)
                {
                    float damage = 1f;
                    pumpk.takeDamage(damage);
                }
            }
            gunFire.Play();
        }     
    }
}
