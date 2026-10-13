using UnityEditor.UI;
using UnityEngine;

public class SkeletonController : Health
{
    [SerializeField] SphereCollider headHitBox;
    [SerializeField] CapsuleCollider bodyHitBox;
    

    // Update is called once per frame
    void Update()
    {
       if (getHP() < 0)
        {
            Destroy(gameObject, lethalHit.clip.length);
        }
    }
}
