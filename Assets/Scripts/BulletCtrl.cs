using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    public float speed = 100.0f;

    private void Awake() {
        StartCoroutine(DestroyBullet());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }


    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(3.0f);

        Destroy(gameObject);
    }
}
