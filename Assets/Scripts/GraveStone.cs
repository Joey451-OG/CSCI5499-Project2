using Unity.VisualScripting;
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
    private bool _canSpawnLock = false;
    private float _spawnTime;
    private int _completedSpawns = 0;
    private int _originalPumpkinCount; 
    void Awake()
    {
       skeletonPrefab = Resources.Load<GameObject>("Skeleton_110"); 
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pumpkins = GameObject.FindGameObjectsWithTag("Pumpkin");
        _spawnTime = float.MaxValue;
        _originalPumpkinCount = pumpkins.Length; 

        foreach (GameObject obj in spawnPoints)
        {
            obj.GetComponentInChildren<GameObject>().SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        pumpkins = GameObject.FindGameObjectsWithTag("Pumpkin");
        _canSpawn = pumpkins.Length <= _originalPumpkinCount - minimumPumpkinsFound;

        
        print(_canSpawn);
        if (_canSpawn && !_canSpawnLock)
        {
            _canSpawnLock = true;
            _spawnTime = Time.time + spawnDelayInSeconds;
        }

        if (_canSpawn && Time.time > _spawnTime)
        {
            _spawnTime = Time.time + spawnDelayInSeconds;
            spawnSkeletons();
        }
    }

    void spawnSkeletons()
    {
        if (_completedSpawns >= spawns)
        {
            return;
        }       

        if (skeletonPrefab == null)
        {
            throw new System.Exception("skeletonPrefab is null! Check that the asset exists at 'Assets/Resources/Skeleton_110.prefab'.");
        }       

        for (int i = 0; i < spawns; i++)
        {
            for (int index = 0; index < spawnPoints.Length; index++)
            {
                Instantiate(skeletonPrefab, spawnPoints[index].transform);
            }

            _completedSpawns = i + 1;
        }
    }
    
}
