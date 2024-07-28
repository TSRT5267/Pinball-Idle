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
    private int ballCount;
    private float spawnTimer;

    [Header("Money")]
    [SerializeField] private int totalMoney;
    

    private void Awake()
    {
        if (instance == null) //�ý��ۻ� �����ϰ� ���� ������
        {
            instance = this; //���ڽ��� instance�� �־��ݴϴ�.
            DontDestroyOnLoad(gameObject); //OnLoad(���� �ε� �Ǿ�����) �ڽ��� �ı����� �ʰ� ����
        }
        else
        {
            if (instance != this) //instance�� �ϳ� ����
                Destroy(this.gameObject); //��� AWake�� �ڽ��� ����
        }

        Screen.SetResolution(900, 1600, true);
    }
    
    void Start()
    {
        //StartCoroutine(SpawnBallRoutine());
        
    }
  
    void Update()
    {
        // ����� �ð� ������Ʈ
        spawnTimer += Time.deltaTime;

        // ������ �ð� ������ ������ �Լ� ȣ��
        if (spawnTimer >= spawnDelay)
        {
            SpawnBall(); // �ֱ������� ������ �Լ� ȣ��
            spawnTimer = 0f; // Ÿ�̸� ����
            animator.Play("SpawnCool", -1, 0);// ��Ÿ�� �ִϸ��̼� �ٽý���
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
        if(ballCount<= maxBall)
        {
            ballCount++;
            GameObject ball = Instantiate(ballPrefab, spawnPoint.position, spawnPoint.rotation);
            Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocityY = Random.Range(minForce, maxForce); // ���� �߻��ϴ� �ӵ� ���� (�ʿ信 ���� ����)
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
