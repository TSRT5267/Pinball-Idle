using UnityEngine;

public class BallScript : MonoBehaviour
{
    private void Update()
    {
        Physics2D.IgnoreLayerCollision(7,7);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {              
        if (collision.gameObject.tag == "Ball End")
        {           
            Destroy(gameObject); // °ø Á¦°Å
        }
    }

    
}
