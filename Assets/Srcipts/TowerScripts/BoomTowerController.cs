using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomTowerController : MonoBehaviour
{
    float countDown = 0f;
    public Transform attackRange;
    public GameObject stone;
    public Transform stoneParentLv1;
    List<GameObject> monsters = new List<GameObject>();
    private float fireRate = 1.5f;
    public float price;
    public float priceUpgrade;
    public int level;
    void Start()
    {
        price = 400;
        priceUpgrade = 130;
        level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (monsters.Count > 0)
        {

            if (monsters[0] != null)
            {

                Shoot(monsters[0]);
            }
            else
            {
                monsters.RemoveAt(0);
            }
        }

    }

    void Shoot(GameObject monster)
    {
        if (countDown > 0)
        {
            countDown -= Time.deltaTime;
        }
        else
        {
            SetShoot(monster);
        }
    }

    private void SetShoot(GameObject monster)
    {

        countDown = fireRate;
        GameObject bullet = Instantiate(stone, stoneParentLv1);
        bullet.transform.position = stoneParentLv1.position;
        bullet.transform.localRotation = stoneParentLv1.rotation;

        //bullet.transform.localPosition = new Vector3(0, 0, 0);
        Vector3 direct = monster.transform.position - bullet.transform.position;
        float angle = Mathf.Atan2(direct.y, direct.x) * Mathf.Rad2Deg;
        bullet.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle));

        float distance = Vector2.Distance(bullet.transform.position, monster.transform.position);
        float time = distance / 3;
        //AudioController.instance.PlaySound("archerShoot");
        bullet.transform.DOMove(monster.transform.position, time).SetEase(Ease.Linear);
    }



    private void OnTriggerEnter2D(Collider2D target)
    {
        Debug.Log(monsters.Count);
        if (target.gameObject.tag.Equals("Monter"))
        {
            monsters.Add(target.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D target)
    {


    }

    private void OnTriggerExit2D(Collider2D target)
    {
        if (target.gameObject.tag.Equals("Monter"))
        {

            monsters.Remove(target.gameObject);

        }
    }
}