using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public GameObject btnBuyTower;
    public GameObject btnTowerBuildOption;
   // public GameObject btnSellTower;
    GameObject currentTower;
    [SerializeField]
    string towerPlacementTag;

    public Button btnBuyArrowTower;
    public Button btnBuyMagicTower;
    public Button btnBuyStoneTower;
    public Button btnBuyBoomTower;

    public GameObject btnSellTower;
    public Button btnUpgradeTower;
    public Text level;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenBtnBuyTower(Transform targetPosition, string placementTag)
    {
        CloseBtnTowerBuildOption();
        btnBuyTower.transform.DOKill();
        btnBuyTower.SetActive(false);
        checkCoinBuyTower();
        btnBuyTower.transform.position = new Vector3(targetPosition.position.x, targetPosition.position.y, btnBuyTower.transform.position.z);
        btnBuyTower.transform.localScale = new Vector3(0, 0, 0);

        btnBuyTower.SetActive(true);
        btnBuyTower.transform.DOScale(1, 0.5f).SetEase(Ease.OutBack);
        towerPlacementTag = placementTag;
    }

    public void checkCoinBuyTower()
    {
        HUD hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        int coin = hud.coin;
        if(coin >= 400)
        {
            btnBuyArrowTower.interactable = true;
            btnBuyMagicTower.interactable = true;
            btnBuyStoneTower.interactable = true;
            btnBuyBoomTower.interactable= true;
        }
        if(coin >= 250 && coin < 400)
        {
            btnBuyArrowTower.interactable = true;
            btnBuyMagicTower.interactable = true;
            btnBuyStoneTower.interactable = true;
            btnBuyBoomTower.interactable = false;
        }
        if(coin >= 150 && coin < 250)
        {
            btnBuyArrowTower.interactable = true;
            btnBuyMagicTower.interactable = true;
            btnBuyStoneTower.interactable = false;
            btnBuyBoomTower.interactable = false;
        }
        if(coin >= 100 && coin < 150)
        {
            btnBuyArrowTower.interactable = true;
            btnBuyMagicTower.interactable = false;
            btnBuyStoneTower.interactable = false;
            btnBuyBoomTower.interactable = false;
        }
        if(coin < 100)
        {
            btnBuyArrowTower.interactable = false;
            btnBuyMagicTower.interactable = false;
            btnBuyStoneTower.interactable = false;
            btnBuyBoomTower.interactable = false;
        }
    }

 

    public void CloseBtnBuyTower()
    {
        btnBuyTower.transform.DOKill();
        btnBuyTower.SetActive(false);
    }

    public void OpenBtnTowerBuildOption(Transform targetPosition, GameObject tower)
    {
        CloseBtnBuyTower();
        CloseAttackRange();

        SetPrice(tower);
        checkCoinUpdate();
        btnTowerBuildOption.transform.DOKill();
        btnTowerBuildOption.SetActive(false);
        btnTowerBuildOption.transform.position = new Vector3(targetPosition.position.x, targetPosition.position.y, btnTowerBuildOption.transform.position.z);
        btnTowerBuildOption.transform.localScale = new Vector3(0, 0, 0);
        btnTowerBuildOption.SetActive(true);
        btnTowerBuildOption.transform.DOScale(1, 0.5f).SetEase(Ease.OutBack);
        currentTower = tower;

        towerPlacementTag = tower.GetComponent<TowerController>().towerPlacementTag;

        OpenAttackRange();
    }
    float priceToSell;
    float priceToUpgrade;
    int towerLevel;
    void SetPrice(GameObject tower)
    {
        if (tower.GetComponent<ArrowTowerController>() != null)
        {
            towerLevel = tower.GetComponent<ArrowTowerController>().level;
            priceToUpgrade = tower.GetComponent<ArrowTowerController>().priceUpgrade;
            priceToSell = tower.GetComponent<ArrowTowerController>().price;
        }else if (tower.GetComponent<MagicTowerController>() != null)
        {
            towerLevel = tower.GetComponent<MagicTowerController>().level;
            priceToUpgrade = tower.GetComponent<MagicTowerController>().priceUpgrade;
            priceToSell = tower.GetComponent<MagicTowerController>().price;
        }
        else if (tower.GetComponent<StoneTowerController>() != null)
        {
            towerLevel = tower.GetComponent<StoneTowerController>().level;
            priceToUpgrade = tower.GetComponent<StoneTowerController>().priceUpgrade;
            priceToSell = tower.GetComponent<StoneTowerController>().price;
        }
        else if (tower.GetComponent<BoomTowerController>() != null)
        {
            towerLevel = tower.GetComponent<BoomTowerController>().level;
            priceToUpgrade = tower.GetComponent<BoomTowerController>().priceUpgrade;
            priceToSell = tower.GetComponent<BoomTowerController>().price;
        }
        priceToSell *= 0.9f;
        level.text = "Level: " + towerLevel; 
        btnUpgradeTower.transform.GetChild(1).GetComponent<Text>().text = priceToUpgrade.ToString();
        btnSellTower.transform.GetChild(1).GetComponent<Text>().text = Mathf.Round(priceToSell).ToString();

    }
    public void checkCoinUpdate()
    {
        HUD hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        int price = int.Parse(priceToUpgrade.ToString());
        if(price > hud.coin)
        {
            btnUpgradeTower.interactable = false;
        }
        else
        {
            btnUpgradeTower.interactable = true;
        }
    }
    public void CloseBtnTowerBuildOption()
    {
        CloseAttackRange();
        btnTowerBuildOption.transform.DOKill();
        btnTowerBuildOption.SetActive(false);
    }
    public void ButtonUpgradeTower()
    {

        //AudioController.instance.PlaySound("upgradeTower");
        HUD hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        int price = int.Parse(priceToUpgrade.ToString());
        hud.SubCoin(price);
        CloseBtnTowerBuildOption();
        TowerManager.instance.UpgradeTower(currentTower);
    }

    public void ButtonSellTower()
    {
        //AudioController.instance.PlaySound("sellTower");
        CloseBtnTowerBuildOption();
        HUD hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        string price = Mathf.Round(priceToSell).ToString();
        hud.AddCoin(int.Parse(price));
        Destroy(currentTower);
        GameObject game = GameObject.FindGameObjectWithTag(towerPlacementTag);
        BoxCollider2D coll = game.GetComponent<BoxCollider2D>();
        coll.enabled = true;
        //TowerManager.instance.towerPlacementParent.GetChild(towerPlacementIndex).gameObject.SetActive(true);
    }

    void OpenAttackRange()
    {
        if (currentTower.GetComponent<ArrowTowerController>() != null)
        {
            currentTower.GetComponent<ArrowTowerController>().attackRange.GetChild(0).gameObject.SetActive(true);
        }
        else if (currentTower.GetComponent<MagicTowerController>() != null)
        {
            currentTower.GetComponent<MagicTowerController>().attackRange.GetChild(0).gameObject.SetActive(true);
        }
        else if (currentTower.GetComponent<StoneTowerController>() != null)
        {
            currentTower.GetComponent<StoneTowerController>().attackRange.GetChild(0).gameObject.SetActive(true);
        }
        else if (currentTower.GetComponent<BoomTowerController>() != null)
        {
            currentTower.GetComponent<BoomTowerController>().attackRange.GetChild(0).gameObject.SetActive(true);
        }
    }

    void CloseAttackRange()
    {
        if (currentTower != null)
        {
            if (currentTower.GetComponent<ArrowTowerController>() != null)
            {
                currentTower.GetComponent<ArrowTowerController>().attackRange.GetChild(0).gameObject.SetActive(false);
            }
            else if (currentTower.GetComponent<MagicTowerController>() != null)
            {
                currentTower.GetComponent<MagicTowerController>().attackRange.GetChild(0).gameObject.SetActive(false);
            }
            else if (currentTower.GetComponent<StoneTowerController>() != null)
            {
                currentTower.GetComponent<StoneTowerController>().attackRange.GetChild(0).gameObject.SetActive(false);
            }
            else if (currentTower.GetComponent<BoomTowerController>() != null)
            {
                currentTower.GetComponent<BoomTowerController>().attackRange.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
}
