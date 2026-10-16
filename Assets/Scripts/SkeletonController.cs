using UnityEngine;
using UnityEngine.AI;

public class SkeletonController : Health
{
    [SerializeField] SphereCollider headHitBox;
    [SerializeField] CapsuleCollider bodyHitBox;
    [SerializeField] public float impactMagnitude = 150f;
    GameObject _player;
    NavMeshAgent _agent;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        _agent.destination = _player.transform.position; 

        if (getHP() < 0)
        {
            Destroy(gameObject, lethalHit.clip.length);
        }
    }
}
