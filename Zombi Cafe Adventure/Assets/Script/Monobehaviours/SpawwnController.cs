using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawwnController : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefabs; // d��man prefab listesi
    [SerializeField] private int spawnGap;  // 2. d��man� olu�turma aral���
    [SerializeField] private List<Transform> spawnPoints; // k��manlar�n olu�turulaca�� farkl� konumlar.

    private GameObject spawnedEnemies;
    private int spawnLocationIndex = 0; // d��man�n hangi noktada ba�lamas� gerekti�ini se�er

    // temporary until GameManager exists for testing
    public bool gameActive = true;


    private void Awake()
    {
        spawnedEnemies = new GameObject();
        spawnedEnemies.name = "Spawned Enemies";

    }

    private void Start()
    {
        StartCoroutine(SpawnMonstersWithGap(3));
       // Debug.Log("SpawnPoints" + spawnPoints.Count);
    }

    IEnumerator SpawnMonstersWithGap(int gap)
    {
        while (gameActive)
        {
            yield return new WaitForSeconds(spawnGap);
            var spawnedEnemy = Instantiate<GameObject>(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)]);

            spawnedEnemy.GetComponent<NavMeshAgent>().enabled = false;
            spawnedEnemy.transform.position = spawnPoints[spawnLocationIndex].position;
            spawnedEnemy.GetComponent <NavMeshAgent>().enabled = true;

            spawnLocationIndex = spawnLocationIndex >= spawnPoints.Count - 1 ? 0 : spawnLocationIndex +1;
            // spawnedEnemy.transform.parent = spawnedEnemies.transform;
        }
        yield break;
    }

    public void StartMonsterWithGapCoRoutine(int gap)
    {

    }

}
