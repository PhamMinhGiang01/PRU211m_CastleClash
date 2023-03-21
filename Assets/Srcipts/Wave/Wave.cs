using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Wave : MonoBehaviour
{
    public static Wave instance;
    [SerializeField]
    public TextMeshProUGUI textWave;

    [SerializeField]
    Button nextWaveButton;

    [SerializeField]
    public GameObject Goblin;

    [SerializeField]
    public GameObject Mushroom;

    [SerializeField]
    public GameObject Minotaur;

    [SerializeField]
    public GameObject DarkWizard;

    [SerializeField]
    public GameObject StartMonster;

    public int wave = 0;
    string wavePrefix = "Wave: ";

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

        //   textWave.text = wavePrefix + wave.ToString();
        nextWaveButton.gameObject.SetActive(true);

    }
    public void Update()
    {
        // textWave.text = wavePrefix + wave.ToString();
        GameObject[] list = GameObject.FindGameObjectsWithTag("Monster");
        if (list.Length == 0)
        {
            nextWaveButton.gameObject.SetActive(true);
        }
        if (list.Length != 0)
        {
            nextWaveButton.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    public void AddWave()
    {
        var wavePre = PlayerPrefs.GetInt("wave");
        wave = wavePre + 1;

        PlayerPrefs.SetInt("wave", wave);
        textWave.text = wavePrefix + wave.ToString();
        GenerateMonster(wave);
    }

    public void SetWave(int wavePre) => textWave.text = wavePrefix + wavePre.ToString();

    private void GenerateMonster(int wave)
    {

        StartCoroutine(GenerateMushroom());

        if (wave >= 3)
        {
            StartCoroutine(GenerateGoblin());
        }
        if (wave >= 6)
        {
            StartCoroutine(GenerateMinotaur());
        }
        if (wave >= 9)
        {
            StartCoroutine(GenerateDarkWizard());
        }
    }

    IEnumerator GenerateMushroom()
    {
        for (int i = 0; i < (3 * wave); i++)
        {
            var mushroom = Instantiate<GameObject>(Mushroom, StartMonster.transform.position, Quaternion.identity);
            mushroom.transform.SetParent(transform);
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator GenerateGoblin()
    {
        for (int i = 0; i < (3 * (wave - 3)); i++)
        {
            var goblin = Instantiate<GameObject>(Goblin, StartMonster.transform.position, Quaternion.identity);
            goblin.transform.SetParent(transform);
            yield return new WaitForSeconds(0.2f);
        }

    }

    IEnumerator GenerateMinotaur()
    {
        for (int i = 0; i < (3 * (wave - 6)); i++)
        {
            var mino = Instantiate<GameObject>(Minotaur, StartMonster.transform.position, Quaternion.identity);
            mino.transform.SetParent(transform);
            yield return new WaitForSeconds(0.2f);
        }

    }

    IEnumerator GenerateDarkWizard()
    {
        for (int i = 0; i < (3 * (wave - 9)); i++)
        {
            var dark = Instantiate<GameObject>(DarkWizard, StartMonster.transform.position, Quaternion.identity);
            dark.transform.SetParent(transform);
            yield return new WaitForSeconds(0.2f);
        }

    }

}
