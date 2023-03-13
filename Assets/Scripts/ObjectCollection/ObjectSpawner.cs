using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


public class ObjectSpawner : MonoBehaviour
{

    [Header("Components")]
    [NonSerialized] private GameObject objectToSpawn;
    
    [Header("Spawn Timer")]
    [SerializeField] private float initialDelay;
    [SerializeField] private float spawnDelay;

    [Header("SpawnDirection")] 
    [Range(0, 360)]
    [SerializeField] private float spawnDirection;
    [Range(0, 360)]
    [SerializeField] private float spawnAngle;
    [SerializeField] private float spawnRangeMax;
    [SerializeField] private float spawnRangeMin;

    [Header("TestValues")] 
    [SerializeField] private bool testBool;
    [SerializeField] private Transform _myTransform;
    [SerializeField] public int maxObjects;
    [SerializeField] public int objects;
    [SerializeField] public SO_Resource Resource;

    

    [Header("GizmoSettings")] 
    [SerializeField] private bool drawGizmos;
    [Range(0,360)]
    [SerializeField] private int edgeIndicators;
    [Range(0.05f, 1f)]
    [SerializeField] private float edgeIndicatorSize = 0.1f;
    [SerializeField] private Color edgeIndicatorColor;

    public bool testingOn;
    public bool shouldSpawn;
    
    private void Awake()
    {
        objects = 0;
        shouldSpawn = true;
    }


    private void Update()
    {
        if (shouldSpawn)
        {
            InitiateEnemy();
        }

        if (objects >= maxObjects)
        {
            shouldSpawn = false;
            DisableSpawning();
        }
        
    }

    private void InitiateEnemy()
    {
        objectToSpawn = Resource.collectables[Random.Range(0, Resource.collectables.Length)];

        var enemy = Instantiate(objectToSpawn, GetRandomSpawnPoint(), Quaternion.identity);
        enemy.transform.LookAt(_myTransform);
        enemy.name = enemy.name.Replace("(Clone)","").Trim();
        objects++;
    }

    public void InitiateSpawning()
    {
        InvokeRepeating(nameof(InitiateEnemy), initialDelay, spawnDelay);
        
    }

    
    
    public void DisableSpawning()
    {
        CancelInvoke(nameof(InitiateEnemy));
    }
    
    private Vector3 GetRandomSpawnPoint()
    {
        float randAngle = Random.Range((-spawnAngle / 2) + spawnDirection,(spawnAngle / 2)+ spawnDirection);
        var randRad = randAngle * Mathf.PI / 180;
        var randDist = Random.Range(spawnRangeMin, spawnRangeMax);
 
        return _myTransform.position + new Vector3(Mathf.Sin(randRad),0 ,Mathf.Cos(randRad))*randDist;
    }

    void OnDrawGizmosSelected()
    {
        if (!drawGizmos) return;
        float halfFOV = spawnAngle / 2.0f;
        
        Quaternion upRayRotation = Quaternion.AngleAxis(-halfFOV + spawnDirection, Vector3.up);
        Quaternion downRayRotation = Quaternion.AngleAxis(halfFOV + spawnDirection, Vector3.up);

        Vector3 spawnIndicatorLeft = upRayRotation * transform.forward * spawnRangeMax;
        Vector3 spawnIndicatorRight = downRayRotation * transform.forward * spawnRangeMax;
        
        Gizmos.color = Color.magenta;
        var position = transform.position;
        Gizmos.DrawRay(position, spawnIndicatorLeft);
        Gizmos.DrawRay(position, spawnIndicatorRight);
        for (int i = 0; i < edgeIndicators; i++)
        {
            var offset = spawnAngle / edgeIndicators;
            Quaternion localRotation = Quaternion.AngleAxis(offset * i + spawnDirection - spawnAngle /2 + offset / 2, Vector3.up);
            var transform1 = transform;
            Vector3 localPosition = localRotation * transform1.forward * spawnRangeMax;
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(localPosition + transform1.position, edgeIndicatorSize);
        }
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRangeMax);


        var forward1 = transform.forward;
        Vector3 safeIndicatorLeft = upRayRotation * forward1 * spawnRangeMin;
        Vector3 safeIndicatorRight = downRayRotation * forward1 * spawnRangeMin;
        
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, safeIndicatorLeft);
        Gizmos.DrawRay(transform.position, safeIndicatorRight);
        Gizmos.DrawWireSphere(transform.position, spawnRangeMin);
    }
}
