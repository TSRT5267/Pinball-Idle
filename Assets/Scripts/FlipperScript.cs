using UnityEngine;

public class FlipperScript : MonoBehaviour
{
    [Header("Filpper")]
    [SerializeField] private KeyCode filpKey;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float  flipperForce;
    [SerializeField] private AudioSource collisionSound;







    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(filpKey))
        {
            Flip();
            
        }

        
    }

    public void Flip()
    {
        
            rb.AddTorque(flipperForce);
        collisionSound.Play();

    }




}
