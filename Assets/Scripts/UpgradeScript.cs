using UnityEngine;
using UnityEngine.UI;

public class UpgradeScript : MonoBehaviour
{
    [SerializeField] private upgradeList upgradeKind;
    [SerializeField] private Text priceText;
    [SerializeField] private Text valueText;
    [SerializeField] private int startPrice;
    [SerializeField] private int addPrice;
    [SerializeField] private int startValue;
    [SerializeField] private int addValue;
    [SerializeField] private Bumpper_Script bumpper;
    [SerializeField] private AutoFilpScript autoFliper1;
    [SerializeField] private AutoFilpScript autoFliper2;

    private AudioSource collisionSound;
    private int price;
    private int value;
    private int nextValue;

    enum upgradeList
    {
        Bumpper,
        AutoFilp,
        MaxBall,
        FireDelay,
    }
    

    

    private void Start()
    {
        collisionSound = GetComponent<AudioSource>();
        price = startPrice;
        value = startValue;
        if(upgradeKind == upgradeList.FireDelay)
            nextValue = startValue - addValue;
        else
            nextValue = startValue + addValue;
    }

    private void Update()
    {
        priceText.text = GameManager.instance.ChangeNumber(price.ToString());
        if (upgradeKind == upgradeList.Bumpper)
        {
            valueText.text = GameManager.instance.ChangeNumber(value.ToString())  
                + " -> " + GameManager.instance.ChangeNumber(nextValue.ToString());
        }
        else if(upgradeKind == upgradeList.AutoFilp)
        {
            if (autoFliper1.OnAutoFilp == false)
                valueText.text = "0 -> Max";
            else 
                valueText.text = "Max";

        }
        else if (upgradeKind == upgradeList.MaxBall)
        {
            if(value != 20)
                valueText.text = GameManager.instance.ChangeNumber(value.ToString()) 
                    + " -> " + GameManager.instance.ChangeNumber(nextValue.ToString());
            else
                valueText.text = "Max";
        }
        else if (upgradeKind == upgradeList.FireDelay)
        {
            if (value != 1)
                valueText.text = GameManager.instance.ChangeNumber(value.ToString()) 
                    + "s -> " + GameManager.instance.ChangeNumber(nextValue.ToString())+"s";
            else
                valueText.text = "Max";
        }
    }


    public void Upgrade()
    {
        if (GameManager.instance.Money >= price)
        {
            if (upgradeKind == upgradeList.Bumpper)
            {

                GameManager.instance.Money -= price;
                bumpper.UpgradeAddMoney(addValue); 
                price = Mathf.RoundToInt(price * addPrice); 
                value += addValue;      
                nextValue += addValue;
                if (bumpper.gameObject.activeSelf == false) //처음에 비활성화시 구매후 활성화
                    bumpper.gameObject.SetActive(true);
                collisionSound.Play();

            }
            else if (upgradeKind == upgradeList.AutoFilp)
            {
                if (autoFliper1.OnAutoFilp == false)
                {
                    GameManager.instance.Money -= price;
                    autoFliper1.OnAutoFilp = true;
                    autoFliper2.OnAutoFilp = true;
                    collisionSound.Play();
                }
            }
            else if (upgradeKind == upgradeList.MaxBall)
            {
                if (value != 20)
                {
                    GameManager.instance.Money -= price;
                    price *= addPrice;
                    value += addValue;
                    nextValue += addValue;
                    GameManager.instance.MaxBall++;
                    collisionSound.Play();
                }

            }
            else if (upgradeKind == upgradeList.FireDelay)
            {
                if (value != 1)
                {
                    GameManager.instance.Money -= price;
                    price *= addPrice;
                    value -= addValue;
                    nextValue -= addValue;
                    GameManager.instance.SpawnDelay--;
                    collisionSound.Play();
                }
            }
        }
    }


}
