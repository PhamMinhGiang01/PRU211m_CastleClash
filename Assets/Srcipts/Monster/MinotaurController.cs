using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinotaurController : MonoBehaviour
{
    int maxHealth = 300;
    int currentHealth = 300;

    [SerializeField]
    public Image heathBar;
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
                Destroy(this.gameObject);
            }
        }
    }
}
