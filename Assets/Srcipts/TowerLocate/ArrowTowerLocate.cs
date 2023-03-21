using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ArrowTowerLocate : MonoBehaviour
{
    public static ArrowTowerLocate instance;
    //[SerializeField]
    //GameObject bullet;
    //int level;
    //int gold;
    //int goldUpdate;
    //int goldUpdateBefore;
    //int damage;
    //int damageIncrease;
    //int damageIncreasBefore;
    //float speed;
    //float scope;
    [SerializeField]
    GameObject tower;
    string tag = GameManage.tagPlace;


    //// Start is called before the first frame update
    //void Start()
    //{
    //    level = 1;
    //    damage = 50;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    GameObject monter = GameObject.FindGameObjectWithTag("Monter");
    //    if(Vector3.Distance(gameObject.transform.position, monter.transform.position) < 1)
    //    {
    //        Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
    //    }
    //}
    //bool CanPlaceTower()
    //{
    //    return tower == null;
    //}
    public string GetPlaceTag()
    {
        return tag;
    }
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
