using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIController2 : MonoBehaviour
{
    public static UIController2 instance;

   
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
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
        //pnlLoading.SetActive(true);
        //float defaultX1 = pnlLoading.transform.GetChild(0).localPosition.x;
        //float defaultX2 = pnlLoading.transform.GetChild(1).localPosition.x;
        //pnlLoading.transform.GetChild(0).DOLocalMoveX(0, 0.5f).SetEase(Ease.Linear);
        //pnlLoading.transform.GetChild(1).DOLocalMoveX(0, 0.5f).SetEase(Ease.Linear);

        yield return new WaitForSeconds(1f);
        AudioController.instance.PlaySound("ingame");
        GameObject gameplay = Instantiate(gameplayPrefab, gameplayParent);
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
        Time.timeScale = 1;


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



}
