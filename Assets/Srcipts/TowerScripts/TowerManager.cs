using UnityEngine;
using UnityEngine.UI;

public class TowerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static TowerManager instance;
    public Transform towerParent;
    public Transform towerPlacementParent;
    public GameObject effectSpawnTower;
    public Sprite arrowTower2;
    public Sprite arrowWeapon2;
    public Sprite arrowTower3;
    public Sprite arrowWeapon3;
    public GameObject arrowlv2;
    public GameObject arrowlv3;

    public Sprite magicTower2;
    public Sprite magicWeapon2;
    public Sprite magicTower3;
    public Sprite magicWeapon3;
    public GameObject magiclv2;
    public GameObject magiclv3;

    public Sprite boomTower2;
    public Sprite boomWeapon2;
    public Sprite boomTower3;
    public Sprite boomWeapon3;
    public GameObject boomlv2;
    public GameObject boomlv3;

    public Sprite stoneTower2;
    public Sprite stoneWeapon2;
    public Sprite stoneTower3;
    public Sprite stoneWeapon3;
    public GameObject stonelv2;
    public GameObject stonelv3;

    public float arrowPrice;
    public float magicPrice;
    public float stonePrice;
    public float boomPrice;

    public GameObject arrowTower;
    public GameObject stoneTower;
    public GameObject boomTower;
    public GameObject magicTower;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        LoadPriceTower();
    }

    public void LoadPriceTower()
    {
        arrowPrice = 100;
        magicPrice = 150;
        stonePrice = 250;
        boomPrice = 400;
       UIController.instance.btnBuyArrowTower.transform.GetChild(1).GetComponent<Text>().text = arrowPrice.ToString();
       UIController.instance.btnBuyMagicTower.transform.GetChild(1).GetComponent<Text>().text = magicPrice.ToString();
       UIController.instance.btnBuyStoneTower.transform.GetChild(1).GetComponent<Text>().text = stonePrice.ToString();
       UIController.instance.btnBuyBoomTower.transform.GetChild(1).GetComponent<Text>().text = boomPrice.ToString();
    }

    public void UpgradeTower(GameObject tower)
    {
        if (tower.GetComponent<ArrowTowerController>() != null)
        {
        
                //tower.GetComponent<ArrowTowerController>().level++;
                int nextLevel = ++tower.GetComponent<ArrowTowerController>().level;
                 
                float priceUpgradeBefore = tower.GetComponent<ArrowTowerController>().priceUpgrade;
                int damageIncreasBefore = tower.GetComponent<ArrowTowerController>().damageIncrease;

                tower.GetComponent<ArrowTowerController>().price += priceUpgradeBefore;
                tower.GetComponent<ArrowTowerController>().priceUpgrade = priceUpgradeBefore + 10 + 2 * ((nextLevel+1) - 3);
                tower.GetComponent<ArrowTowerController>().damage += damageIncreasBefore;
                tower.GetComponent<ArrowTowerController>().damageIncrease = damageIncreasBefore + 4 + 2 * ((nextLevel+1) - 3);
                tower.GetComponent<ArrowTowerController>().speed += 0.05f;

            if (nextLevel == 10)
            {
                SpriteRenderer spriteRenderer = tower.GetComponent<SpriteRenderer>();
                SpriteRenderer spriteRenderer1 = tower.transform.GetChild(0).GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = arrowTower2;
                spriteRenderer1.sprite = arrowWeapon2;
                tower.GetComponent<ArrowTowerController>().arrow = arrowlv2;
            }
            if (nextLevel == 20)
            {
                SpriteRenderer spriteRenderer = tower.GetComponent<SpriteRenderer>();
                SpriteRenderer spriteRenderer1 = tower.transform.GetChild(0).GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = arrowTower3;
                spriteRenderer1.sprite = arrowWeapon3;
                Vector3 position = tower.transform.GetChild(0).transform.position;
                position.y += 0.2f;
                tower.transform.GetChild(0).transform.position = position;
                tower.GetComponent<ArrowTowerController>().arrow = arrowlv3;
            }
        }
        else if (tower.GetComponent<MagicTowerController>() != null)
        {
            int nextLevel = ++tower.GetComponent<MagicTowerController>().level;

            float priceUpgradeBefore = tower.GetComponent<MagicTowerController>().priceUpgrade;
            int damageIncreasBefore = tower.GetComponent<MagicTowerController>().damageIncrease;

            tower.GetComponent<MagicTowerController>().price += priceUpgradeBefore;
            tower.GetComponent<MagicTowerController>().priceUpgrade = priceUpgradeBefore + 10 + 2 * ((nextLevel + 1) - 3);
            tower.GetComponent<MagicTowerController>().damage += damageIncreasBefore;
            tower.GetComponent<MagicTowerController>().damageIncrease = damageIncreasBefore + 4 + 2 * ((nextLevel + 1) - 3);
            tower.GetComponent<ArrowTowerController>().speed += 0.05f;
            if (nextLevel == 10)
            {
                SpriteRenderer spriteRenderer = tower.GetComponent<SpriteRenderer>();
                SpriteRenderer spriteRenderer1 = tower.transform.GetChild(0).GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = magicTower2;
                spriteRenderer1.sprite = magicWeapon2;
                tower.GetComponent<MagicTowerController>().magic = magiclv2;
            }
            if (nextLevel == 20)
            {
                SpriteRenderer spriteRenderer = tower.GetComponent<SpriteRenderer>();
                SpriteRenderer spriteRenderer1 = tower.transform.GetChild(0).GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = magicTower3;
                spriteRenderer1.sprite = magicWeapon3;
                Vector3 position = tower.transform.GetChild(0).transform.position;
                position.y += 0.2f;
                tower.transform.GetChild(0).transform.position = position;
                tower.GetComponent<MagicTowerController>().magic = magiclv3;
            }
        }
        else if (tower.GetComponent<StoneTowerController>() != null)
        {
            int nextLevel = ++tower.GetComponent<StoneTowerController>().level;

            float priceUpgradeBefore = tower.GetComponent<StoneTowerController>().priceUpgrade;
            int damageIncreasBefore = tower.GetComponent<StoneTowerController>().damageIncrease;

            tower.GetComponent<StoneTowerController>().price += priceUpgradeBefore;
            tower.GetComponent<StoneTowerController>().priceUpgrade = priceUpgradeBefore + 10 + 2 * ((nextLevel + 1) - 3);
            tower.GetComponent<StoneTowerController>().damage += damageIncreasBefore;
            tower.GetComponent<StoneTowerController>().damageIncrease = damageIncreasBefore + 4 + 2 * ((nextLevel + 1) - 3);
            tower.GetComponent<ArrowTowerController>().speed += 0.05f;
            if (nextLevel == 10)
            {
                SpriteRenderer spriteRenderer = tower.GetComponent<SpriteRenderer>();
               //SpriteRenderer spriteRenderer1 = tower.transform.GetChild(0).GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = stoneTower2;
                //spriteRenderer1.sprite = boomWeapon2;
                tower.GetComponent<StoneTowerController>().stone = stonelv2;
            }
            if (nextLevel == 20)
            {
                SpriteRenderer spriteRenderer = tower.GetComponent<SpriteRenderer>();
                //SpriteRenderer spriteRenderer1 = tower.transform.GetChild(0).GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = stoneTower3;
                //spriteRenderer1.sprite = boomWeapon3;
                //Vector3 position = tower.transform.GetChild(0).transform.position;
                //position.y += 0.2f;
                //tower.transform.GetChild(0).transform.position = position;
                tower.GetComponent<StoneTowerController>().stone = stonelv3;
            }
        }
        else if (tower.GetComponent<BoomTowerController>() != null)
        {
            int nextLevel = ++tower.GetComponent<BoomTowerController>().level;

            float priceUpgradeBefore = tower.GetComponent<BoomTowerController>().priceUpgrade;
            int damageIncreasBefore = tower.GetComponent<BoomTowerController>().damageIncrease;

            tower.GetComponent<BoomTowerController>().price += priceUpgradeBefore;
            tower.GetComponent<BoomTowerController>().priceUpgrade = priceUpgradeBefore + 10 + 2 * ((nextLevel + 1) - 3);
            tower.GetComponent<BoomTowerController>().damage += damageIncreasBefore;
            tower.GetComponent<BoomTowerController>().damageIncrease = damageIncreasBefore + 4 + 2 * ((nextLevel + 1) - 3);
            tower.GetComponent<ArrowTowerController>().speed += 0.05f;
            if (nextLevel == 10)
            {
                SpriteRenderer spriteRenderer = tower.GetComponent<SpriteRenderer>();
                SpriteRenderer spriteRenderer1 = tower.transform.GetChild(0).GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = boomTower2;
                spriteRenderer1.sprite = boomWeapon2;
                tower.GetComponent<BoomTowerController>().stone = boomlv2;
            }
            if (nextLevel == 20)
            {
                SpriteRenderer spriteRenderer = tower.GetComponent<SpriteRenderer>();
                SpriteRenderer spriteRenderer1 = tower.transform.GetChild(0).GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = boomTower3;
                spriteRenderer1.sprite = boomWeapon3;
                Vector3 position = tower.transform.GetChild(0).transform.position;
                position.y += 0.2f;
                tower.transform.GetChild(0).transform.position = position;
                tower.GetComponent<BoomTowerController>().stone = boomlv3;
            }
        }
    }

    //public IEnumerator LoadTower(GameObject tower, int towerPlacementIndex, int level)
    //{
    //    Transform towerPlacement = towerPlacementParent.GetChild(towerPlacementIndex);

    //    GameObject effectSpawn = Instantiate(effectSpawnTower);
    //    effectSpawn.transform.position = towerPlacement.position;

    //    yield return new WaitForSeconds(0.4f);

    //    GameObject newTower = Instantiate(tower);
    //    newTower.transform.SetParent(towerParent);
    //    towerPlacement.gameObject.SetActive(false);
    //    newTower.transform.position = towerPlacement.position;
    //    newTower.GetComponent<TowerController>().towerPlacementIndex = towerPlacementIndex;

    //    if (newTower.GetComponent<ArrowTowerController>() != null)
    //    {
    //        if (level == 1)
    //        {
    //        }
    //        else if (level == 2)
    //        {
    //            StartCoroutine(UpgradeTower(newTower));
    //        }
    //        else if (level == 3)
    //        {
    //            StartCoroutine(UpgradeTower(newTower));
    //            StartCoroutine(UpgradeTower(newTower));
    //        }
    //        else if (level == 4)
    //        {
    //            StartCoroutine(UpgradeTower(newTower));
    //            StartCoroutine(UpgradeTower(newTower));
    //            StartCoroutine(UpgradeTower(newTower));
    //        }


    //    }
    //    else if (newTower.GetComponent<StoneTowerController>() != null)
    //    {
    //        if (level == 1)
    //        {
    //        }
    //        else if (level == 2)
    //        {
    //            StartCoroutine(UpgradeTower(newTower));
    //        }
    //        else if (level == 3)
    //        {
    //            StartCoroutine(UpgradeTower(newTower));
    //            StartCoroutine(UpgradeTower(newTower));
    //        }
    //        else if (level == 4)
    //        {
    //            StartCoroutine(UpgradeTower(newTower));
    //            StartCoroutine(UpgradeTower(newTower));
    //            StartCoroutine(UpgradeTower(newTower));
    //        }
    //    }
    //    else if (newTower.GetComponent<MagicTowerController>() != null)
    //    {
    //        if (level == 1)
    //        {
    //        }
    //        else if (level == 2)
    //        {
    //            StartCoroutine(UpgradeTower(newTower));
    //        }
    //        else if (level == 3)
    //        {
    //            StartCoroutine(UpgradeTower(newTower));
    //            StartCoroutine(UpgradeTower(newTower));
    //        }
    //        else if (level == 4)
    //        {
    //            StartCoroutine(UpgradeTower(newTower));
    //            StartCoroutine(UpgradeTower(newTower));
    //            StartCoroutine(UpgradeTower(newTower));
    //        }
    //    }
    //    else if (newTower.GetComponent<MagicTowerController>() != null)
    //    {
    //        if (level == 1)
    //        {
    //        }
    //        else if (level == 2)
    //        {
    //            StartCoroutine(UpgradeTower(newTower));
    //        }
    //        else if (level == 3)
    //        {
    //            StartCoroutine(UpgradeTower(newTower));
    //            StartCoroutine(UpgradeTower(newTower));
    //        }
    //        else if (level == 4)
    //        {
    //            StartCoroutine(UpgradeTower(newTower));
    //            StartCoroutine(UpgradeTower(newTower));
    //            StartCoroutine(UpgradeTower(newTower));
    //        }
    //    }

    //}
}
