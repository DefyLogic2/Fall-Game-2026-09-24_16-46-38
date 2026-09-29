using UnityEngine;
using UnityEngine.UI;
public class ButtonUpgrades : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  
    public GameManager gameManager;      // drag your GameManager object here
    public Button buttonToEnable;
    public bool disableThisButton = false;  // drag the other button here
    public int cost = 10;                // however much this action costs
    public bool _1 = false;
    public bool _2 = false;
    public bool _3 = false;
    public bool _4 = false;
    public bool _5 = false;
    public bool EnableButton = false;
    public void OnButtonClicked()
    {

        if (gameManager.leavesAmount >= cost)
        {
            gameManager.removeManna(cost);
            if(EnableButton == true)
            {
                buttonToEnable.interactable = true;
            }
            if (_1 == true)
            {
                One();
            }
            if(_2 == true)
            {
                Two();
            }
            if(_3 == true)
            {
                Three();
            }


        }
    }

    void Update()
    {

    }

    public void One()
    {
        if(gameManager.Water < 100)
        {
            gameManager.Water += 10;
        }
        
      

    }
    public void Two()
    {
      if(gameManager.leavesAmount > 30)
        {
            gameManager.leavesAmount -= 30;
            {
                gameManager.MannaGenerator();
                if (disableThisButton)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }
    public void Three()
    {
        if (gameManager.leavesAmount > 10)
        {
            gameManager.leavesAmount -= 10;
            gameManager.EnableOnHoldCollection();
            if(disableThisButton)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
