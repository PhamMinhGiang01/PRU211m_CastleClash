using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{

    [SerializeField]
    public TextMeshProUGUI scoreText;

    [SerializeField]
    public TextMeshProUGUI coinText;
    int score = 0;
    int coin = 500;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
        coinText.text = coin.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore(int s)
    {
        score += s;
        scoreText.text = score.ToString();
    }
    public void AddCoin(int c)
    {
        coin += c;
        coinText.text = coin.ToString();
    }
}
