using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour
{
    [SerializeField] private AudioSource collisionSound;

    private float timer;
    private float waitTime=0.2f;

    void Awake()
    {
         

       
        Physics2D.IgnoreLayerCollision(7, 7); // 공끼리는 서로 충돌X
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(timer> waitTime)
        {
            collisionSound.Play();
            timer = 0;
        }


        if (collision.gameObject.tag == "Ball End")
        {
            GameManager.instance.BallCount--;           
            gameObject.SetActive(false); // 비활성화
        }

        
    }

    
}
