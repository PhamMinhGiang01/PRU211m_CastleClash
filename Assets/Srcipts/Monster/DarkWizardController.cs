using UnityEngine;
using UnityEngine.UI;

public class DarkWizardController : MonoBehaviour
{
    int maxHealth = 800;
    int Score = 50;
    int Coin = 50;
    public int currentHealth = 200;

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
    //void OnCollisionEnter2D(Collision2D coll)
    //{
    //    if (coll.gameObject.CompareTag("Bullet"))
    //    {
    //        currentHealth -= 20;
    //        heathBar.fillAmount = (float)currentHealth / maxHealth;
    //        if (currentHealth <= 0)
    //        {
    //            HUD hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
    //            hud.AddScore(Score);
    //            hud.AddCoin(Coin);
    //            Instantiate<GameObject>(smokeExplosion, this.gameObject.transform.position, Quaternion.identity);
    //            Destroy(this.gameObject);
    //        }
    //    }
    //}
}
