using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 3;
    public int damage = 5;
    public float speed = 5.0f;
    public bool isDead = false;

    public GameObject playerBase;
    
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        playerBase = GameObject.Find("Base");
        rb = this.GetComponent<Rigidbody>();
        //Debug.Log($"{gameObject.name} hp: {hp}");
        //Debug.Log($"{gameObject.name} damage: {damage}");
        //Debug.Log($"{gameObject.name} speed: {speed}");
    }

    // Update is called once per frame
    void Update()
    {
        if(playerBase != null && !isDead)
        {
            Transform tr_Base = playerBase.transform;
            Vector3 dir = tr_Base.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime);
            //transform.rotation = Quaternion.LookRotation(dir.normalized, Vector3.up);
        }
        // 체력이 모두 소진되면 키네마틱 해제 및 3초 뒤 제거
        if(hp <= 0 && !isDead)
        {
            GameManager.instance.enemyCount += 1;
            this.rb.isKinematic = false;
            Invoke("DestroyEnemy", 3.0f);
            isDead = true;
        }
    }

    public void HitProjectile(int n)
    {
        hp -= n;
    }

    void DestroyEnemy(){
        Destroy(gameObject);
    }

}
