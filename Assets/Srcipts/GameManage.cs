using UnityEngine;

public class GameManage : MonoBehaviour
{
    //[SerializeField]
    //GameObject tower;
    // Start is called before the first frame update
    public static Vector3 position;
    public static bool isBuild;
    public static string tagPlace ="";
    public static string tagPlace1 = "";
    public static GameObject tower;
    void Start()
    {
        position = new Vector3();
        isBuild = new bool();
        tagPlace = new string("");
        tagPlace1 = new string("");
        tower = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector3 position = transform.position;
        //    position.z = -Camera.main.transform.position.z;
        //    position = Camera.main.ScreenToWorldPoint(position);
        //    Instantiate(tower, position, Quaternion.identity);
        //}
        //if (oldPositon != newPosition)
        //{
        //    Destroy(GameObject.FindGameObjectWithTag("choosetower"));
        //    count = 0;
        //}
    }
}
