using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour
{
    

    void Awake()
    {
         

       
        Physics2D.IgnoreLayerCollision(7, 7); // �������� ���� �浹X
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {              
        if (collision.gameObject.tag == "Ball End")
        {           
            Destroy(gameObject); // �� ����
        }

        
    }

    
}
