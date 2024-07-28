using UnityEngine;
using UnityEngine.UI;

public class UpgradeScript : MonoBehaviour
{
    [SerializeField] private Text priceText;
    [SerializeField] private Text valueText;
    [SerializeField] private int startPrice;
    [SerializeField] private int addPrice;
    [SerializeField] private int startValue;
    [SerializeField] private int addValue;
    [SerializeField] private Bumpper_Script bumpper;
    private int price;
    private int value;
    private int nextValue;

    private void Start()
    {
        price = startPrice;
        value = startValue;
        nextValue = value * 2;
    }

    private void Update()
    {
        priceText.text = price.ToString();
        valueText.text = value.ToString()+" -> " + nextValue.ToString();
    }


    public void Upgrade()
    {
        if (GameManager.instance.Money >= price)
        {
            GameManager.instance.Money -= price;
            bumpper.UpgradeAddMoney(addValue);
            price = Mathf.RoundToInt(price * addPrice);
            value += addValue;
            nextValue += addValue;

        }
    }
   


}
