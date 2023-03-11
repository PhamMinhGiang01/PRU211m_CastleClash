using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTowerDestroy : MonoBehaviour
{
    string tag = GameManage.tagPlace1;
    GameObject objectTow = GameManage.tower;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUp()
    {
        GameObject.FindGameObjectWithTag(tag).GetComponent<BoxCollider2D>().enabled = true;
        GameManage.isBuild = true;
        Destroy(objectTow);
        Destroy(GameObject.FindGameObjectWithTag("buildoption"));
    }
}
