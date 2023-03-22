using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIController2 : MonoBehaviour
{
    [SerializeField] private Text speedText, scoreTextGameOver;
    public static UIController2 instance;
    public Text txtGameSpeed;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Time.timeScale = 1f;
    }

    [Header("Panel Home")]
    public GameObject pnlHome;
    public GameObject pnlIngame;
    //public GameObject pnlLoading;
    public GameObject gameplayPrefab;
    public Transform gameplayParent;

    public void ButtonPlay()
    {
        StartCoroutine(DelayPlay());
    }

    IEnumerator DelayPlay()
    {
        SetUpNewGame();
        gameplayParent.gameObject.SetActive(true);
        PlayerPrefs.SetInt("wave", 0);
        DOVirtual.DelayedCall(.2f, () =>
        {
            GameplayController.instance.GetData();
        });

        //pnlLoading.SetActive(true);
        //float defaultX1 = pnlLoading.transform.GetChild(0).localPosition.x;
        //float defaultX2 = pnlLoading.transform.GetChild(1).localPosition.x;
        //pnlLoading.transform.GetChild(0).DOLocalMoveX(0, 0.5f).SetEase(Ease.Linear);
        //pnlLoading.transform.GetChild(1).DOLocalMoveX(0, 0.5f).SetEase(Ease.Linear);

        yield return new WaitForSeconds(1f);
        AudioController.instance.PlaySound("ingame");
        GameObject gameplay = Instantiate(gameplayPrefab, gameplayParent);
        GameManage.gameplayPrefab= gameplay;
        gameplay.transform.position = Vector3.zero;
        pnlHome.SetActive(false);
        pnlIngame.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        //pnlLoading.transform.GetChild(0).DOLocalMoveX(defaultX1, 0.5f).SetEase(Ease.Linear);
        //pnlLoading.transform.GetChild(1).DOLocalMoveX(defaultX2, 0.5f).SetEase(Ease.Linear);

        yield return new WaitForSeconds(1f);

        //pnlLoading.SetActive(false);
    }

    public void ButtonHome()
    {
        StartCoroutine(DelayHome());
    }


    IEnumerator DelayHome()
    {
        SetUpOutGame();
        Time.timeScale = 1;
        pnlIngame.SetActive(true);
        pnlLose.SetActive(false);

        //pnlLoading.SetActive(true);
        //float defaultX1 = pnlLoading.transform.GetChild(0).localPosition.x;
        //float defaultX2 = pnlLoading.transform.GetChild(1).localPosition.x;
        //pnlLoading.transform.GetChild(0).DOLocalMoveX(0, 0.5f).SetEase(Ease.Linear);
        //pnlLoading.transform.GetChild(1).DOLocalMoveX(0, 0.5f).SetEase(Ease.Linear);

        yield return new WaitForSeconds(1f);

        Destroy(gameplayParent.GetChild(0).gameObject);
        pnlHome.SetActive(true);
        pnlIngame.SetActive(false);
        pnlPause.SetActive(false);
        AudioController.instance.PlaySound("mainMenu");

        yield return new WaitForSeconds(0.5f);

        //pnlLoading.transform.GetChild(0).DOLocalMoveX(defaultX1, 0.5f).SetEase(Ease.Linear);
        //pnlLoading.transform.GetChild(1).DOLocalMoveX(defaultX2, 0.5f).SetEase(Ease.Linear);

        yield return new WaitForSeconds(1f);

        //pnlLoading.SetActive(false);
    }



    [Header("Panel Setting")]
    public GameObject pnlSetting;
    public GameObject soundOn;
    public GameObject soundOff;


    public void ButtonOpenSetting()
    {
        pnlSetting.transform.GetChild(0).localScale = Vector3.zero;
        pnlSetting.SetActive(true);
        pnlSetting.transform.GetChild(0).DOScale(1, 0.5f).SetEase(Ease.OutBack);
    }

    public void ButtonCloseSetting()
    {
        pnlSetting.transform.GetChild(0).DOScale(0, 0.5f).SetEase(Ease.InBack).OnComplete(() =>
        {
            pnlSetting.SetActive(false);
        });
    }

    public void ButtonSound()
    {
        if (AudioController.instance.Sound == 1)
        {
            AudioController.instance.Sound = 0;
        }
        else
        {
            AudioController.instance.Sound = 1;
        }
    }

    [Header("Panel Pause")]
    public GameObject pnlPause;

    public void OpenPanelPause()
    {
        Time.timeScale = 0;
        pnlPause.transform.GetChild(0).localScale = Vector3.zero;
        pnlPause.SetActive(true);
        pnlPause.transform.GetChild(0).DOScale(1, 0.5f).SetEase(Ease.OutBack).SetUpdate(true);
    }

    public void ButtonContinue()
    {
        pnlPause.transform.GetChild(0).DOScale(0, 0.5f).SetEase(Ease.InBack).SetUpdate(true).OnComplete(() =>
        {
            pnlPause.SetActive(false);
            Time.timeScale = 1;

        });
    }

    public void ButtonRestart()
    {
        StartCoroutine(DelayRestart());
    }

    IEnumerator DelayRestart()
    {
        Time.timeScale = 1;
        txtGameSpeed.text = "x1";
        SetUpNewGame();


        //pnlLoading.SetActive(true);
        //float defaultX1 = pnlLoading.transform.GetChild(0).localPosition.x;
        //float defaultX2 = pnlLoading.transform.GetChild(1).localPosition.x;
        //pnlLoading.transform.GetChild(0).DOLocalMoveX(0, 0.5f).SetEase(Ease.Linear);
        //pnlLoading.transform.GetChild(1).DOLocalMoveX(0, 0.5f).SetEase(Ease.Linear);

        yield return new WaitForSeconds(1f);

        pnlPause.SetActive(false);
        pnlLose.SetActive(false);

        if (gameplayParent.childCount > 0) Destroy(gameplayParent.GetChild(0).gameObject);

        yield return new WaitForSeconds(0.5f);

        Instantiate(gameplayPrefab, gameplayParent);

        yield return new WaitForSeconds(0.5f);

        //pnlLoading.transform.GetChild(0).DOLocalMoveX(defaultX1, 0.5f).SetEase(Ease.Linear);
        //pnlLoading.transform.GetChild(1).DOLocalMoveX(defaultX2, 0.5f).SetEase(Ease.Linear);

        yield return new WaitForSeconds(1f);

        //pnlLoading.SetActive(false);

    }

    [Header("Panel Lose")]
    public GameObject pnlLose;
    public Transform background;
    public Transform btnHome;
    public Transform btnReplay;

    public void OpenPanelLose()
    {
        StartCoroutine(DelayOpenPanelLose());
    }
    IEnumerator DelayOpenPanelLose()
    {
        btnHome.localScale = Vector3.zero;
        btnReplay.localScale = Vector3.zero;
        background.localScale = Vector3.zero;
        pnlLose.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        pnlLose.SetActive(true);

        pnlLose.GetComponent<Image>().DOFade(0.5f, 0.5f);
        background.DOScale(1, 0.5f).SetEase(Ease.OutBack);

        yield return new WaitForSeconds(1f);

        btnReplay.DOScale(1, 0.5f).SetEase(Ease.OutBack);
        btnHome.DOScale(1, 0.5f).SetEase(Ease.OutBack);
    }
    public void ButtonSave()
    {
        StartCoroutine(DelaySave());

    }

    IEnumerator DelaySave()
    {
        SetUpOutGame();
        Time.timeScale = 1;
        txtGameSpeed.text = "x1";
        yield return new WaitForSeconds(1f);
        GameplayController.instance.SetData(CastleController.instance.health, HUD.instance.coin, Wave.instance.wave, HUD.instance.score);
        print(HUD.instance.coin);


        // //BinaryFormatter formatter = new BinaryFormatter();
        // ////string path =  Application.persistentDataPath + "/PlayerData.xml";
        // //string path= (Path.Combine(Application.persistentDataPath, "PlayerData.xml"));
        // //Debug.Log(path.ToString());
        // //FileStream stream = new FileStream(path, FileMode.Create);
        // string path = Application.persistentDataPath;
        // string authorsFile = "data.json";
        // if (File.Exists(Path.Combine(path, authorsFile)))
        // {
        //     // If file found, delete it    
        //     File.Delete(Path.Combine(path, authorsFile)); // delete file
        // }
        // int type = 0;
        // int index = 0;
        // int level = 0;
        // int wave = 0;
        // int health = 0;
        // float coin = 0;


        // List<SaveData> saveDatas = new List<SaveData>();
        // foreach (Transform tower in gameplayParent.GetChild(0).GetChild(2))
        // {
        //     if (tower.GetComponent<ArrowTowerController>() != null)
        //     {
        //         type = 1;
        //         index = tower.GetComponent<TowerController>().towerPlacementIndex;
        //         level = tower.GetComponent<ArrowTowerController>().level;
        //         wave = Wave.instance.wave;
        //         print(wave);
        //         health = PlayerSetting.instance.Health;
        //         coin = PlayerSetting.instance.Coin;
        //         SaveData saveData = new SaveData(type, index, level, wave, health, coin);
        //         saveDatas.Add(saveData);


        //     }
        //     else if (tower.GetComponent<StoneTowerController>() != null)
        //     {
        //         type = 2;
        //         index = tower.GetComponent<TowerController>().towerPlacementIndex;
        //         level = tower.GetComponent<StoneTowerController>().level;
        //         wave = Wave.instance.wave;
        //         health = PlayerSetting.instance.Health;
        //         coin = PlayerSetting.instance.Coin;
        //         print(wave);

        //         SaveData saveData = new SaveData(type, index, level, wave, health, coin);
        //         saveDatas.Add(saveData);
        //     }
        //     else if (tower.GetComponent<MagicTowerController>() != null)
        //     {
        //         type = 3;
        //         index = tower.GetComponent<TowerController>().towerPlacementIndex;
        //         level = tower.GetComponent<MagicTowerController>().level;
        //         wave = Wave.instance.wave;
        //         health = PlayerSetting.instance.Health;
        //         coin = PlayerSetting.instance.Coin;
        //         print(wave);

        //         SaveData saveData = new SaveData(type, index, level, wave, health, coin);
        //         saveDatas.Add(saveData);
        //     }
        //     else if (tower.GetComponent<BoomTowerController>() != null)
        //     {
        //         type = 4;
        //         index = tower.GetComponent<TowerController>().towerPlacementIndex;
        //         level = tower.GetComponent<BoomTowerController>().level;
        //         wave = Wave.instance.wave;
        //         health = PlayerSetting.instance.Health;
        //         coin = PlayerSetting.instance.Coin;
        //         print(wave);

        //         SaveData saveData = new SaveData(type, index, level, wave, health, coin);
        //         saveDatas.Add(saveData);
        //     }
        //     var Json = JsonConvert.SerializeObject(saveDatas, Formatting.Indented); // convert t? list game object sang json
        //     File.WriteAllText(Path.Combine(path, authorsFile), Json); // save vào file
        // }



        gameplayParent.GetChild(0).gameObject.SetActive(false);
        pnlHome.SetActive(true);
        pnlIngame.SetActive(false);
        pnlLose.SetActive(false);
        pnlPause.SetActive(false);
        AudioController.instance.PlaySound("mainMenu");

        yield return new WaitForSeconds(0.5f);


        yield return new WaitForSeconds(1f);
    }

    public void ButtonLoad()
    {
        StartCoroutine(DelayLoad());
    }
    IEnumerator DelayLoad()
    {
        SetUpOutGame();
            AudioController.instance.PlaySound("ingame");
            //GameObject gameplay = Instantiate(GameManage.gameplayPrefab, gameplayParent);
            //gameplay.transform.position = Vector3.zero;
            gameplayParent.GetChild(0).gameObject.SetActive(true);
        pnlHome.SetActive(false);
        pnlIngame.SetActive(true);
        GameplayController.instance.GetData();

        yield return new WaitForSeconds(0.5f);

        // string path = Application.persistentDataPath;
        // string authorsFile = "data.json";
        // string jsonFilePath = Path.Combine(path, authorsFile);

        // if (!File.Exists(jsonFilePath))
        // {
        //     yield return new WaitForSeconds(0.5f);
        // }
        // else
        // {
        //     string json = File.ReadAllText(jsonFilePath);
        //     var ob = JsonConvert.DeserializeObject<List<SaveData>>(json);

        //     foreach (SaveData data in ob)
        //     {
        //         if (data.type == 1)
        //         {

        //             StartCoroutine(TowerManager.instance.LoadTower(TowerManager.instance.arrowTower, data.index, data.level));
        //             PlayerSetting.instance.Coin = data.coin;
        //             PlayerSetting.instance.Health = data.health;
        //             Wave.instance.wave = data.wave;
        //             GameplayController.instance.UpdateWave(data.wave);

        //         }
        //         else if (data.type == 2)
        //         {
        //             StartCoroutine(TowerManager.instance.LoadTower(TowerManager.instance.stoneTower, data.index, data.level));
        //             PlayerSetting.instance.Coin = data.coin;
        //             PlayerSetting.instance.Health = data.health;
        //             Wave.instance.wave = data.wave;
        //             GameplayController.instance.UpdateWave(data.wave);
        //         }
        //         else if (data.type == 3)
        //         {
        //             StartCoroutine(TowerManager.instance.LoadTower(TowerManager.instance.magicTower, data.index, data.level));
        //             PlayerSetting.instance.Coin = data.coin;
        //             PlayerSetting.instance.Health = data.health;
        //             Wave.instance.wave = data.wave;
        //             GameplayController.instance.UpdateWave(data.wave);
        //         }
        //         else if (data.type == 4)
        //         {
        //             StartCoroutine(TowerManager.instance.LoadTower(TowerManager.instance.boomTower, data.index, data.level));
        //             PlayerSetting.instance.Coin = data.coin;
        //             PlayerSetting.instance.Health = data.health;
        //             Wave.instance.wave = data.wave;
        //             GameplayController.instance.UpdateWave(data.wave);

        //         }
        //     }
        //     File.Delete(jsonFilePath);
        // }

    }

    public void IncreaseSpeed()
    {
        if (Time.timeScale < 4) Time.timeScale += 1;
        else Time.timeScale = 1;
        speedText.text = "x" + Time.timeScale.ToString();
    }

    private void SetUpNewGame()
    {
        DestroyAll("StoneTower");
        DestroyAll("MagicTower");
        DestroyAll("BoomTower");
        DestroyAll("ArrowTower");

    }

    private void DestroyAll(string tag)
    {
        GameObject[] tower = GameObject.FindGameObjectsWithTag(tag);
        for (int i = 0; i < tower.Length; i++)
        {
            GameObject.Destroy(tower[i]);
        }
    }

    public void SetUpOutGame() => DestroyAll("Monster");

    public void DisplayScore(int scoreCurrent) => scoreTextGameOver.text = scoreCurrent.ToString();
}

