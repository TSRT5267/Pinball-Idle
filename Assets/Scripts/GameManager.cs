using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [Header("BallSpawner")]
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnDelay;
    [SerializeField] private float minForce;
    [SerializeField] private float maxForce;
    [SerializeField] private int maxBall;
    [SerializeField] private int ballPoolSize;
    [SerializeField] private Transform ballObjectPool;
    private List<GameObject> pools = new List<GameObject>(); // 풀
     private int ballCount=0;
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
        for (int i = 0; i < ballPoolSize; i++)
        {
            GameObject ball = Instantiate(ballPrefab, ballObjectPool);
            ball.gameObject.SetActive(false);
            pools.Add(ball);
        } // 풀 초기화


    }

    void Update()
    {
        // 경과한 시간 업데이트
        spawnTimer += Time.deltaTime;

        // 지정된 시간 간격이 지나면 함수 호출
        if (spawnTimer >= spawnDelay)
        {
            SpawnBall(); // 주기적으로 실행할 함수 호출
            spawnTimer = 0f; // 타이머 리셋
            animator.Play("SpawnCool", -1, 0);// 쿨타임 애니메이션 다시시작

            
        }
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
        if(ballCount < maxBall)
        {
            ballCount++;
            //GameObject ball = Instantiate(ballPrefab, spawnPoint.position, spawnPoint.rotation);
            //Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
            /*if (rb != null)
            {
                rb.velocityY = Random.Range(minForce, maxForce); // 공을 발사하는 속도 설정 (필요에 따라 조정)
            }*/

            // 오브젝트 풀링
            for (int i = 0; i < ballPoolSize; i++)
            {
                if (!pools[i].activeInHierarchy) // 하이라키 창에 pools[i]가 비활성화일 때
                {
                    
                    pools[i].transform.position = spawnPoint.position;
                    pools[i].transform.rotation = spawnPoint.rotation;
                    pools[i].SetActive(true); // 탄환 사용
                    pools[i].GetComponent<Rigidbody2D>().velocityY = Random.Range(minForce, maxForce); // 방향
                    break;
                }
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
        set
        {
            totalMoney = value;
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

    public float SpawnTimer
    {
        get
        {
            return spawnTimer;
        }
        set
        {
            spawnTimer = value;
        }

    }

    public float SpawnDelay
    {
        get
        {
            return spawnDelay;
        }
        set
        {
            spawnDelay = value;
        }

    }

}
