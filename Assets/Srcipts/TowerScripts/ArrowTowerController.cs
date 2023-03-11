using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class ArrowTowerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject BuilOption;
    GameObject choose;
    string tag = GameManage.tagPlace;
    public static Vector3 placeTower = new Vector3(0, 0, 0);

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    int count = 0;
   
    private void OnMouseUp()
    {
        Vector3 oldPositon = GameManage.position;
        Vector3 newPosition = transform.position;
        GameManage.position = transform.position;

        if (oldPositon != newPosition)
        {
            Destroy(GameObject.FindGameObjectWithTag("choosetower"));
            Destroy(GameObject.FindGameObjectWithTag("buildoption"));
            count = 0;
        }

        GameManage.tagPlace1 = tag;
        GameManage.tower = gameObject;
        
        // Create Build Option
        count++;
        if (count == 1)
        {
            choose = Instantiate(BuilOption, transform.position, Quaternion.identity);
        }
        if (count == 2)
        {
            Destroy(choose);
            count = 0;
        }

    }
}
