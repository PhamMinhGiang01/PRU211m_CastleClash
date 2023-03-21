using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CastleController : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI textHealthCastle;
    public static CastleController instance;
   public  int health = 20;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        SetHealth(health);
    }
    public void SetHealth(int healthPre) => textHealthCastle.text = healthPre.ToString();
    // Update is called once per frame
    void Update()
    {
        
    }
    private void SubHealth()
    {
        if (health > 1) health--;
        else
        {
            UIController2.instance.pnlLose.SetActive(true);
            UIController2.instance.gameplayParent.gameObject.SetActive(false);
            UIController2.instance.DisplayScore(HUD.instance.score);
        }

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Monster"))
        {
            SubHealth();
            textHealthCastle.text = health.ToString();
            Destroy(coll.gameObject);
        }
    }
}
