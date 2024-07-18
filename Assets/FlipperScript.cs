using UnityEngine;

public class FlipperScript : MonoBehaviour
{
    [Header("Filpper")]
    [SerializeField] private KeyCode filpKey;
    [SerializeField] private Rigidbody2D rb;
   
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(filpKey))
        {           
            rb.AddTorque(10000f);
        }
    }
}
