﻿using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using TMPro;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    //public SpriteRenderer background;
    int fingerID = -1;
    Vector3 touchStart;
    public TextMeshProUGUI waveText;

    //public SpriteRenderer map;
    public LayerMask towerPlacementLayer;
    public LayerMask towerLayer;
    private float mapMinX, mapMinY, mapMaxX, mapMaxY;
    private float zoomOutMin, zoomOutMax;
    private bool isMultiTouch = false;
    private bool isDragging = false;

    private void Awake()
    {

        instance = this;
        //        Camera.main.orthographicSize = background.bounds.size.x * Screen.height / Screen.width * 0.5f;
        //#if !UNITY_EDITOR
        fingerID = 0;
        //#endif
    }

    public void UpdateWave(int wave) => waveText.text = wave.ToString();


    // Start is called before the first frame update
    void Start()
    {
        //GetMapSize();
        //Debug.Log(Application.persistentDataPath);
        //PlayerSetting.instance.Coin = 300;
        //PlayerSetting.instance.Health = 15;
    }


    public void SetData(int health, int coin, int wave, int score)
    {
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetInt("health", health);
        PlayerPrefs.SetInt("coin", coin);
       if(wave > 0) PlayerPrefs.SetInt("wave", wave  -1);
       else PlayerPrefs.SetInt("wave", wave);
    }

    public void GetData()
    {
        DOVirtual.DelayedCall(.2f, () =>
        {
            HUD.instance.SetScore(PlayerPrefs.GetInt("score"));
            CastleController.instance.SetHealth(PlayerPrefs.GetInt("health"));
            HUD.instance.SetCoin(PlayerPrefs.GetInt("coin"));
             Wave.instance.SetWave(PlayerPrefs.GetInt("wave"));
        });

    }


    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject(fingerID))
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            isDragging = false;
            isMultiTouch = false;
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        //if (Input.touchCount == 2)
        //{
        //    if (!UIController.instance.btnBuyTower.activeSelf && !UIController.instance.btnUpgradeAndSellTower.activeSelf)
        //    {
        //        isMultiTouch = true;
        //        Touch touchZero = Input.GetTouch(0);
        //        Touch touchOne = Input.GetTouch(1);

        //        Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
        //        Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

        //        float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
        //        float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

        //        float difference = currentMagnitude - prevMagnitude;

        //        Zoom(difference * 0.01f);
        //    }
        //}
        //else if (Input.GetMouseButton(0) && !isMultiTouch)
        //{
        //    if (!UIController.instance.btnBuyTower.activeSelf && !UIController.instance.btnUpgradeAndSellTower.activeSelf)
        //    {
        //        Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //        if (direction.x > 0.02f || direction.x < -0.02f || direction.y > 0.02f || direction.y < -0.02f)
        //        {
        //            isDragging = true;
        //        }

        //        Camera.main.transform.position = ClampCamera(Camera.main.transform.position + direction);
        //    }
        //}

        if (Input.GetMouseButtonUp(0))
        {
            if (!isDragging && !isMultiTouch)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, towerPlacementLayer);

                if (hit.collider != null)
                {
                    if (hit.collider.tag.Contains("place"))
                    {

                        GameManage.position = GameObject.FindGameObjectWithTag(hit.collider.tag).transform.position;
                        GameManage.tagPlace = hit.collider.tag;
                        UIController.instance.OpenBtnBuyTower(hit.collider.transform, hit.collider.tag);
                    }
                }
                else
                {
                    UIController.instance.CloseBtnBuyTower();

                    hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, towerLayer);
                    if (hit.collider != null)
                    {

                        if (hit.collider.tag.Contains("Tower"))
                        {

                            //GameManage.tower = hit.collider.gameObject.transform.parent.gameObject;
                            UIController.instance.OpenBtnTowerBuildOption(hit.collider.transform, hit.collider.gameObject.transform.parent.gameObject);
                        }
                    }
                    else
                    {

                        UIController.instance.CloseBtnTowerBuildOption();
                    }
                }


            }
        }

        //if (!UIController.instance.btnBuyTower.activeSelf && !UIController.instance.btnUpgradeAndSellTower.activeSelf)
        //{
        //    Zoom(Input.GetAxis("Mouse ScrollWheel"));
        //}

    }

    //void Zoom(float increment)
    //{
    //    Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    //    Camera.main.transform.position = ClampCamera(Camera.main.transform.position);
    //}

    //private void GetMapSize()
    //{
    //    zoomOutMin = 1;
    //    zoomOutMax = Camera.main.orthographicSize;

    //    mapMinX = map.transform.position.x - map.bounds.size.x / 2f;
    //    mapMaxX = map.transform.position.x + map.bounds.size.x / 2f;

    //    mapMinY = map.transform.position.y - map.bounds.size.y / 2f;
    //    mapMaxY = map.transform.position.y + map.bounds.size.y / 2f;
    //}

    //private Vector3 ClampCamera(Vector3 targetPosition)
    //{
    //    float camHeight = Camera.main.orthographicSize;
    //    float camWidth = Camera.main.orthographicSize * Camera.main.aspect;

    //    float minX = mapMinX + camWidth;
    //    float maxX = mapMaxX - camWidth;
    //    float minY = mapMinY + camHeight;
    //    float maxY = mapMaxY - camHeight;

    //    float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
    //    float newy = Mathf.Clamp(targetPosition.y, minY, maxY);

    //    return new Vector3(newX, newy, targetPosition.z);
    //}


}
