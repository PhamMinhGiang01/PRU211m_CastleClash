using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public GameObject btnBuyTower;
    public GameObject btnTowerBuildOption;
   // public GameObject btnSellTower;
    GameObject currentTower;
    [SerializeField]
    string towerPlacementTag;
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
        btnBuyTower.transform.position = new Vector3(targetPosition.position.x, targetPosition.position.y, btnBuyTower.transform.position.z);
        btnBuyTower.transform.localScale = new Vector3(0, 0, 0);
        btnBuyTower.SetActive(true);
        btnBuyTower.transform.DOScale(1, 0.5f).SetEase(Ease.OutBack);
        towerPlacementTag = placementTag;
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

        //SetPrice(tower);
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
    public void CloseBtnTowerBuildOption()
    {
        CloseAttackRange();
        btnTowerBuildOption.transform.DOKill();
        btnTowerBuildOption.SetActive(false);
    }

    public void ButtonSellTower()
    {
        //AudioController.instance.PlaySound("sellTower");
        //PlayerSetting.instance.Coin += priceToSell;
        CloseBtnTowerBuildOption();
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
            Debug.Log("helloArrow");
            currentTower.GetComponent<ArrowTowerController>().attackRange.GetChild(0).gameObject.SetActive(true);
        }
        else if (currentTower.GetComponent<MagicTowerController>() != null)
        {
            Debug.Log("helloMagic");
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
