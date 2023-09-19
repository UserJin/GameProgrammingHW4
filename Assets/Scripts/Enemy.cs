using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp = 100.0f;
    public float damage = 10.0f;
    public float speed = 5.0f;

    public float movingCooltime = 3.0f;
    public float lastTime = 3.0f;

    public float x = 0;
    public float z = 0;

    private void Awake() {
        StartCoroutine(DestroyEnemy());
    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log($"{gameObject.name} hp: {hp}");
        //Debug.Log($"{gameObject.name} damage: {damage}");
        //Debug.Log($"{gameObject.name} speed: {speed}");
    }

    // Update is called once per frame
    void Update()
    {
        // movingCooltime이 될때 마다 이동 방향을 랜덤하게 변경
        if(lastTime >= movingCooltime)
        {
            x = Random.Range(0.0f, 2.0f) - 1.0f;
            z = Random.Range(0.0f, 2.0f) - 1;
            lastTime = 0.0f;
        }
        transform.Translate(x*speed*Time.deltaTime, 0.0f, z*speed*Time.deltaTime);
        lastTime += Time.deltaTime;
    }

    IEnumerator DestroyEnemy()
    {
        // 15초 뒤 자동으로 제거
        yield return new WaitForSeconds(15.0f);

        Destroy(gameObject);
    }

}
