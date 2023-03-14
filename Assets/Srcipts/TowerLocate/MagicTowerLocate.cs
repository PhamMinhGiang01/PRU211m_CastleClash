using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTowerLocate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject tower;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Click()
    {
        GameObject newTower = Instantiate(tower, GameManage.position, Quaternion.identity);
        newTower.GetComponent<TowerController>().towerPlacementTag = GameManage.tagPlace;
        //GameObject.FindGameObjectWithTag(GameManage.tag).SetActive(false);
        GameObject game = GameObject.FindGameObjectWithTag(GameManage.tagPlace);
        BoxCollider2D coll = game.GetComponent<BoxCollider2D>();
        coll.enabled = false;
        // Destroy(GameObject.FindGameObjectWithTag("choosetower"));
    }
}
