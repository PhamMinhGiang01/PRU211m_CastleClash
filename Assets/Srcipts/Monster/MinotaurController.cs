using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinotaurController : MonoBehaviour
{
    int maxHealth = 300;
    int Score = 30;
    int Coin = 30;

    int currentHealth = 300;

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
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Bullet"))
        {
            currentHealth -= 20;
            heathBar.fillAmount = (float)currentHealth / maxHealth;
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
}
