using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public Text bulletText;
    public Transform firePoint;

    public GameObject bulletPrefab;
    public GameObject novaPrefab;
    public int bulletCount = 10;
    public int novaCount = 20;

    private List<GameObject> bulletPool = new List<GameObject>();
    private List<GameObject> novaPool = new List<GameObject>();

    public float bulletForce = 20f;
    
    public static Shooting instance;
    void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < bulletCount; i++) {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
        for (int i = 0; i < novaCount; i++) {
            GameObject nova = Instantiate(novaPrefab);
            nova.SetActive(false);
            novaPool.Add(nova);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }

        bulletText.text = BulletRemaining().ToString();
    }

    void Shoot() {
        //GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        GameObject bullet = GetPooledObject();
        if (bullet != null) {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.SetActive(true);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }

        
    }

    public GameObject GetPooledObject() {
        for(int i = 0; i < bulletCount; i++) {
            if (!bulletPool[i].activeInHierarchy) return bulletPool[i];
        }
        return null;
    }

    public GameObject GetPooledNova() {
        for(int i = 0; i < novaCount; i++) {
            if (!novaPool[i].activeInHierarchy) return novaPool[i];
        }
        return null;
    }

    public int BulletRemaining() {
        int count = 0;
        for (int i = 0; i < bulletCount; i++)
            count = !bulletPool[i].activeInHierarchy ? count + 1 : count;
        return count;
    }
}
