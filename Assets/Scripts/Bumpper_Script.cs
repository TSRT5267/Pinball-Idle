using UnityEngine;

public class Bumpper_Script : MonoBehaviour
{
    [SerializeField] private int MoneyValue;
    


    public void AddMoney()
    {
        GameManager.instance.AddMoney(MoneyValue);
    }
}
