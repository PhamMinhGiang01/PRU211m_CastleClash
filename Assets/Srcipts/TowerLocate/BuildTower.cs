using UnityEngine;

public class BuildTower : MonoBehaviour
{
    [SerializeField]
    GameObject Choosetower;
    // Start is called before the first frame update
    GameObject choose;
    bool buil;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManage.isBuild)
        {
            buil = true;
            OnMouseUp();
            GameManage.isBuild = false;
        }
    }

    int count = 0;
    private void OnMouseUp()
    {
 
        Vector3 oldPositon = GameManage.position;
        Vector3 newPosition = transform.position;
        GameManage.position = transform.position;
        GameManage.tagPlace = gameObject.tag;
        if (buil)
        {
            return;
        }

        if (oldPositon != newPosition)
        {
            Destroy(GameObject.FindGameObjectWithTag("choosetower"));
            Destroy(GameObject.FindGameObjectWithTag("buildoption"));
            count = 0;
        }
        
        count++;
        if (count == 1)      
        {
            choose = Instantiate(Choosetower, transform.position, Quaternion.identity);
            //UIController.instance.OpenBtnBuyTower(transform);
        }
        if(count == 2)
        {

            Destroy(choose);
            count = 0;
        }
    }




}
