using UnityEngine;

public class BallScript : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {              
        if (collision.gameObject.tag == "Ball End")
        {           
            Destroy(gameObject); // �� ����
        }
    }

    
}
