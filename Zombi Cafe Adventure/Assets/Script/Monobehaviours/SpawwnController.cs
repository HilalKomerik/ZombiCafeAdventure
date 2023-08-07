using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawwnController : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefabs; // düþman prefab listesi
    [SerializeField] private int spawnGap;  // 2. düþmaný oluþturma aralýðý
    [SerializeField] private List<Transform> spawnPoints; // küþmanlarýn oluþturulacaðý farklý konumlar.

    private GameObject spawnedEnemies;
    private int spawnLocationIndex = 0; // düþmanýn hangi noktada baþlamasý gerektiðini seçer

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
