using UnityEngine;

public class PumpkinController : Health
{
    // Update is called once per frame
    void Update()
    {
        if (getHP() < 0)
        {
            Destroy(gameObject, lethalHit.clip.length);
        }   
    }
}
