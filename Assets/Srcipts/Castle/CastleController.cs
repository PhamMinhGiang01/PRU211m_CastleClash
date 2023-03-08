using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CastleController : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI textHealthCastle;

    int health = 20;
    // Start is called before the first frame update
    void Start()
    {
        textHealthCastle.text = health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Monster"))
        {
            health -= 1;
            if(health <= 0)
            {
                Time.timeScale = 0;
            }
            textHealthCastle.text = health.ToString();
            Destroy(coll.gameObject);
        }
    }
}
