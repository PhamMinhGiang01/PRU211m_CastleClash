using UnityEngine;

public class TowerController : MonoBehaviour
{
    public static TowerController instance;
    public int towerPlacementIndex;
    public string towerPlacementTag;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
