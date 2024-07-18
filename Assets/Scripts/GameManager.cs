using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("BallSpawner")]
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnDelay;
    [SerializeField] private float minForce;
    [SerializeField] private float maxForce;
    
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnBallRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnBallRoutine()
    {
        while (true)
        {
            SpawnBall();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void SpawnBall()
    {
        GameObject ball = Instantiate(ballPrefab, spawnPoint.position, spawnPoint.rotation);
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocityY =  Random.Range(minForce,maxForce); // 공을 발사하는 속도 설정 (필요에 따라 조정)
        }
    }

    
}
