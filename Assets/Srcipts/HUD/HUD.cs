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
    string scorePrefix = "Score: ";
    int coin = 500;
    string coinPrefix = "Coin: ";

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = scorePrefix + score.ToString();
        coinText.text = coinPrefix + coin.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore(int s)
    {
        score += s;
        scoreText.text = scorePrefix + score.ToString();
    }
    public void AddCoin(int c)
    {
        coin += c;
        coinText.text = coinPrefix + coin.ToString();
    }
}
