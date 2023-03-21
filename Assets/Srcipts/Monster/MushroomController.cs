using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MushroomController : MonoBehaviour
{
    int Health = 100;
    int Score = 10;
    int Coin = 10;

    public int currentHealth = 100;

    [SerializeField]
    public Image heathBar;

    [SerializeField]
    public GameObject smokeExplosion;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        heathBar.fillAmount = (float)currentHealth / Health;
        if (currentHealth <= 0)
        {
            HUD hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
            hud.AddScore(Score);
            hud.AddCoin(Coin);
            Instantiate<GameObject>(smokeExplosion, this.gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
