using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnEnable() {
        //Destroy(gameObject, 5f);
        StartCoroutine(DisableIE());
    }

    IEnumerator DisableIE() {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }


    void OnCollisionEnter2D(Collision2D collision) {
        gameObject.SetActive(false);
        GameObject nova = Shooting.instance.GetPooledNova();
        if (nova != null) {
            nova.SetActive(true);
            nova.transform.position = transform.position;
            nova.transform.rotation = Quaternion.identity;
        }
    }
}
