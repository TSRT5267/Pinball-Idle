using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [Header("BallSpawner")]
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnDelay;
    [SerializeField] private float minForce;
    [SerializeField] private float maxForce;
    [SerializeField] private int maxBall;
    private int ballCount;
    private float spawnTimer;

    [Header("Money")]
    [SerializeField] private int totalMoney;
    

    private void Awake()
    {
        if (instance == null) //시스템상에 존재하고 있지 않을때
        {
            instance = this; //내자신을 instance로 넣어줍니다.
            DontDestroyOnLoad(gameObject); //OnLoad(씬이 로드 되었을때) 자신을 파괴하지 않고 유지
        }
        else
        {
            if (instance != this) //instance가 하나 존재
                Destroy(this.gameObject); //방금 AWake된 자신을 삭제
        }

        Screen.SetResolution(900, 1600, true);
    }
    
    void Start()
    {
        StartCoroutine(SpawnBallRoutine());
        spawnTimer = spawnDelay;
    }
  
    void Update()
    {
        
    }

    IEnumerator SpawnBallRoutine()
    {
        while (true)
        {
            SpawnBall();
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    public void SpawnBall()
    {
        if(ballCount<= maxBall)
        {
            ballCount++;
            spawnTimer = spawnDelay;
            GameObject ball = Instantiate(ballPrefab, spawnPoint.position, spawnPoint.rotation);
            Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocityY = Random.Range(minForce, maxForce); // 공을 발사하는 속도 설정 (필요에 따라 조정)
            }
        }
        
    }

    public void AddMoney(int money)
    {
        totalMoney += money;
    }

    //------------------------------------------------------------

    public int Money
    {
        get
        {
            return totalMoney; 
        }
        
    }

    public int BallCount
    {
        get
        {
            return ballCount; 
        }

        set
        {
            ballCount = value;
        }

    }

    public int SpawnTimer
    {
        get
        {
            return ballCount;
        }
        set
        {
            spawnTimer = value;
        }

    }

}
