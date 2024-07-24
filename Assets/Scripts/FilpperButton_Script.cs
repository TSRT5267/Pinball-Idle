using UnityEngine;

public class FilpperButton_Script : MonoBehaviour
{
    [SerializeField] private FlipperScript filpper;

    
    

    private void OnMouseDown()
    {
        filpper.Filp();
        
    }

}
