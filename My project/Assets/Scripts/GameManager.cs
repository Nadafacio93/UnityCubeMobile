using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    public float spawnInterval = 2f;
    public bool isGameOver = false;
    public float spawnY = 11f;
    public float spawnX = 7f;

    void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    private IEnumerator SpawnObstacle()
    {
        while (!isGameOver)
        {
            var obstacleSpawn = Random.Range(1, 4);
            for(int i = 0; i < obstacleSpawn; i++)
            {
                var xPosition = Random.Range(-spawnX, spawnX);
                var damping = Random.Range(0f, 2f);
                var objObstacle = Instantiate(obstaclePrefab, new Vector3(xPosition, spawnY, 0), Quaternion.identity);

                objObstacle.GetComponent<Rigidbody>().linearDamping = damping;
            }
            

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
