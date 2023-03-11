using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneTowerLocate : MonoBehaviour
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
