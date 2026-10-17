using UnityEngine;

public class GraveStone : MonoBehaviour
{
    
    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] int spawns = 1;
    [SerializeField] int minimumPumpkinsFound = 0;
    [SerializeField] float spawnDelayInSeconds = 0f;

    GameObject[] pumpkins;
    GameObject skeletonPrefab;
    private bool _canSpawn = false;
    private float _spawnTime;

    void Awake()
    {
       skeletonPrefab = Resources.Load<GameObject>("Skeleton_110"); 
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _spawnTime = float.PositiveInfinity;

        foreach (GameObject obj in spawnPoints)
        {
            obj.SetActive(false);
        }

        pumpkins = GameObject.FindGameObjectsWithTag("Pumpkin");
    }

    // Update is called once per frame
    void Update()
    {
        _canSpawn = pumpkins.Length <= pumpkins.Length - minimumPumpkinsFound;

        if (_canSpawn && Time.time > _spawnTime)
        {
            spawnSkeletons();

        } else if (_canSpawn)
        {
            _spawnTime = Time.time + spawnDelayInSeconds;
        }
    }

    void spawnSkeletons()
    {
        if (skeletonPrefab == null)
        {
            throw new System.Exception("skeletonPrefab is null! Check that the asset exists at 'Assets/Resources/Skeleton_110.prefab'.");
        }       

        for (int i = 0; i < spawns; i++)
        {
            for (int index = 0; index < spawnPoints.Length; index++)
            {
                Instantiate(skeletonPrefab, spawnPoints[i].transform);
            }
        }
    }
    
}
