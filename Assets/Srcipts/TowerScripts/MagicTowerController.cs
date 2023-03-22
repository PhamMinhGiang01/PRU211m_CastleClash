using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTowerController : MonoBehaviour
{
    float countDown = 0f;
    public Transform attackRange;
    public GameObject magic;
    public Transform arrowParentLv1;
    List<GameObject> monsters = new List<GameObject>();

    private float fireRate = 1.5f;
    
    public float price;
    public float priceUpgrade;
    public int level;
    public int damage;
    public int damageIncrease;
    public float speed;
    void Start()
    {
        price = 150;
        priceUpgrade = 70;
        level = 1;
        damage = 60;
        damageIncrease = 20;
        speed = 5;
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
            StartCoroutine(SetShoot(monster));
        }
    }

    private IEnumerator SetShoot(GameObject monster)
    {
       
        countDown = fireRate;
        GameObject bullet = Instantiate(magic, arrowParentLv1);
        bullet.transform.position = arrowParentLv1.position;
        bullet.transform.localRotation = arrowParentLv1.rotation;

        //bullet.transform.localPosition = new Vector3(0, 0, 0);
        Vector3 direct = monster.transform.position - bullet.transform.position;
        float angle = Mathf.Atan2(direct.y, direct.x) * Mathf.Rad2Deg;
        bullet.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle));

        float distance = Vector2.Distance(bullet.transform.position, monster.transform.position);
        float time = distance / speed;
        //AudioController.instance.PlaySound("archerShoot");
        bullet.transform.DOMove(monster.transform.position, time).SetEase(Ease.Linear);
        yield return new WaitForSeconds(time);
        Destroy(bullet);
        if (monster != null)
        {
            if (monster.GetComponent<MushroomController>() != null)
            {
                monster.GetComponent<MushroomController>().TakeDamage(damage);
            }
            if (monster.GetComponent<GoblinController>() != null)
            {
                monster.GetComponent<GoblinController>().TakeDamage(damage);
            }
            if (monster.GetComponent<MinotaurController>() != null)
            {
                monster.GetComponent<MinotaurController>().TakeDamage(damage);
            }
            if (monster.GetComponent<DarkWizardController>() != null)
            {
                monster.GetComponent<DarkWizardController>().TakeDamage(damage);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag.Equals("Monster"))
        {
            monsters.Add(target.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D target)
    {
        if (target.gameObject.tag.Equals("Monster"))
        {
            GameObject monster = target.gameObject;
            if (monster.GetComponent<MushroomController>() != null)
            {
                if (monster.GetComponent<MushroomController>().currentHealth <= 0)
                {
                    if (monsters.IndexOf(monster) >= 0)
                    {
                        monsters.Remove(monster);
                    }
                }
            }
            if (monster.GetComponent<GoblinController>() != null)
            {
                if (monster.GetComponent<GoblinController>().currentHealth <= 0)
                {
                    if (monsters.IndexOf(monster) >= 0)
                    {
                        monsters.Remove(monster);
                    }
                }
            }
            if (monster.GetComponent<MinotaurController>() != null)
            {
                if (monster.GetComponent<MinotaurController>().currentHealth <= 0)
                {
                    if (monsters.IndexOf(monster) >= 0)
                    {
                        monsters.Remove(monster);
                    }
                }
            }
            if (monster.GetComponent<DarkWizardController>() != null)
            {
                if (monster.GetComponent<DarkWizardController>().currentHealth <= 0)
                {
                    if (monsters.IndexOf(monster) >= 0)
                    {
                        monsters.Remove(monster);
                    }
                }
            }
        }

    }

    private void OnTriggerExit2D(Collider2D target)
    {
        if (target.gameObject.tag.Equals("Monster"))
        {
            monsters.Remove(target.gameObject);
        }
    }
}
