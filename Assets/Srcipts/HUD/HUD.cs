using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{

    public static HUD instance;
    [SerializeField]
    public TextMeshProUGUI scoreText;

    [SerializeField]
    public TextMeshProUGUI coinText;
    public int score = 0;
    public int coin = 500;
    private void Awake()
    {
        instance = this;
    }

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

    public void SetCoin(int cointPre) => coinText.text = cointPre.ToString();
    public void SetScore(int scorePre) => scoreText.text = scorePre.ToString();
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
    public void SubCoin(int c)
    {
        coin -= c;
        coinText.text = coin.ToString();
    }
}
