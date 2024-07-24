using UnityEngine;

public class FlipperScript : MonoBehaviour
{
    [Header("Filpper")]
    [SerializeField] private KeyCode filpKey;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float  flipperForce;
   
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(filpKey))
        {
            Filp();
        }
    }

    public void Filp()
    {
        
            rb.AddTorque(flipperForce);
        
    }
}
