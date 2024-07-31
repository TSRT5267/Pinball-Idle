using UnityEngine;
using UnityEngine.UI;

public class MoneyText : MonoBehaviour
{
    [SerializeField] private Text text;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = GameManager.instance.ChangeNumber(GameManager.instance.Money.ToString()); 
        
    }
}
