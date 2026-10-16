using UnityEditor.UI;
using UnityEngine;

public class SkeletonController : Health
{
    [SerializeField] SphereCollider headHitBox;
    [SerializeField] CapsuleCollider bodyHitBox;
    [SerializeField] public float impactMagnitude = 150f;
    

    // Update is called once per frame
    void Update()
    {
       if (getHP() < 0)
        {
            Destroy(gameObject, lethalHit.clip.length);
        }
    }
}
