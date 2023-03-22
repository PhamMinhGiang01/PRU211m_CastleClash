using UnityEngine;
using UnityEngine.UI;

public class ArrowTowerLocate : MonoBehaviour
{
    public static ArrowTowerLocate instance;

    [SerializeField]
    GameObject tower;
 


    // Start is called before the first frame update
    //void Start()
    //{
    //}

    // Update is called once per frame
    //void Update()
    //{
 
    //}

    public void click()
    {
        HUD hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        string coin = UIController.instance.btnBuyArrowTower.transform.GetChild(1).GetComponent<Text>().text;
        hud.SubCoin(int.Parse(coin));
        GameObject newTower = Instantiate(tower, GameManage.position, Quaternion.identity);
        newTower.GetComponent<TowerController>().towerPlacementTag= GameManage.tagPlace;
        //GameObject.FindGameObjectWithTag(GameManage.tag).SetActive(false);
        GameObject game = GameObject.FindGameObjectWithTag(GameManage.tagPlace);
        BoxCollider2D coll = game.GetComponent<BoxCollider2D>();
        coll.enabled = false;
       // Destroy(GameObject.FindGameObjectWithTag("choosetower"));
    }


}
