using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovaDisable : MonoBehaviour
{
    void OnEnable() {
        //Destroy(gameObject, 5f);
        StartCoroutine(DisableIE());
    }

    IEnumerator DisableIE() {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
