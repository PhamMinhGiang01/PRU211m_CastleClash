using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTowerLocate : MonoBehaviour
{
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

    private void OnMouseUp()
    {
        Instantiate(tower, GameManage.position, Quaternion.identity);
        //GameObject.FindGameObjectWithTag(GameManage.tag).SetActive(false);
        GameObject game = GameObject.FindGameObjectWithTag(GameManage.tagPlace);
        BoxCollider2D coll = game.GetComponent<BoxCollider2D>();
        coll.enabled = false;
        Destroy(GameObject.FindGameObjectWithTag("choosetower"));
    }


}
