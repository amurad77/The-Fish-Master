using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScreensManager : MonoBehaviour
{
    public static ScreensManager instance;
    
    private GameObject currentSceen;

    public GameObject endScreen;
    public GameObject gameScreen;
    public GameObject mainScreen;
    public GameObject returnScreen;

    public Button lenghtButton;
    public Button strengthButton;
    public Button offlineButton;

    public Text gameScreenMoney;
    public Text lengthCostText;
    public Text lengthValueText;
    public Text strengthCostText;
    public Text strengthValueText;
    public Text offlineCostText;
    public Text offlineValueText;
    public Text endScreenMoney;
    public Text returnScreenMoney;

    private int gameCount;

    void Awake()
    {
        if (ScreensManager.instance)
            Destroy(base.gameObject);
        else
            ScreensManager.instance = this;

        currentSceen = mainScreen;
    }


    void Start()
    {
       CheckIdles();
       UpdateTexts(); 
    }

    public void ChangeScreen( Screens screen)
    {
        currentSceen.SetActive(false);
        switch (screen)
        {
            case Screens.MAIN:
                currentSceen = mainScreen;
                UpdateTexts();
                CheckIdles();
                break;

            case Screens.GAME:
                currentSceen = gameScreen;
                gameCount++;
                break;

            case Screens.END:
                currentSceen = endScreen;
                SetEndScreenMoney();
                break;

            case Screens.RETURN:
                currentSceen = gameScreen;
                SetReturnScreenMoney();
                break;
        }
        currentSceen.SetActive(true);
    }

    public void SetEndScreenMoney()
    {
        endScreenMoney.text = "$" + IdleManager.instance.totalGain;
    }
    
    public void SetReturnScreenMoney()
    {
        returnScreenMoney.text = "$" + IdleManager.instance.totalGain + " gained while waiting!";
    }

    void UpdateTexts()
    {
        gameScreenMoney.text = "$" + IdleManager.instance.wallet;
        lengthCostText.text = "$" + IdleManager.instance.lengthCost;
        lengthValueText.text = -IdleManager.instance.length + "m";
        strengthCostText.text = "$" + IdleManager.instance.strengthCost;
        strengthValueText.text = IdleManager.instance.strength + " fishes.";
        offlineCostText.text = "$" + IdleManager.instance.offlineEarningsCost;
        offlineValueText.text = "$" + IdleManager.instance.offlineEarnings + "/main";

    }

    void CheckIdles()
    {
        int lengthCost = IdleManager.instance.lengthCost;
        int strengthCost = IdleManager.instance.strengthCost;
        int offlineEarningsCost = IdleManager.instance.offlineEarningsCost;
        int wallet = IdleManager.instance.wallet;

        if (wallet < lengthCost)
            lenghtButton.interactable = false;
        else
            lenghtButton.interactable = true;

        
        if (wallet < lengthCost)
            strengthButton.interactable = false;
        else
            strengthButton.interactable = true;

        
        if (wallet < lengthCost)
            offlineButton.interactable = false;
        else
            offlineButton.interactable = true;
    }
}
