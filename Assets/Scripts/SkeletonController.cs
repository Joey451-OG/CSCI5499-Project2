using UnityEngine;
using UnityEngine.AI;

public class SkeletonController : Health
{
    [SerializeField] SphereCollider headHitBox;
    [SerializeField] CapsuleCollider bodyHitBox;
    [SerializeField] public float impactMagnitude = 150f;
    [SerializeField] float hitDistance = 1f;
    [SerializeField] float hitDamage = 10f;
    [SerializeField] float timeUntilNextHitInSeconds = 1f;
    Health _player;
    NavMeshAgent _agent;
    float _nextHitTime;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        _agent = GetComponent<NavMeshAgent>();
        _nextHitTime = timeUntilNextHitInSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        _agent.destination = _player.transform.position; 

        if (Time.time > _nextHitTime && Vector3.Distance(transform.position, _player.transform.position) < hitDistance)
        {
            _nextHitTime = Time.time + timeUntilNextHitInSeconds;
            _agent.destination = transform.position;
            _player.takeDamage(hitDamage);
        }

        if (getHP() < 0)
        {
            Destroy(gameObject, lethalHit.clip.length);
        }
    }
}
