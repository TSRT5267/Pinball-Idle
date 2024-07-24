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

    private int totalMoney;
    private int maxBall;

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
    }
    
    void Start()
    {
        
    }
  
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

    public void SpawnBall()
    {
        GameObject ball = Instantiate(ballPrefab, spawnPoint.position, spawnPoint.rotation);
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocityY =  Random.Range(minForce,maxForce); // ���� �߻��ϴ� �ӵ� ���� (�ʿ信 ���� ����)
        }
    }

    
}
