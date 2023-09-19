using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float hp = 100.0f;
    public float damage = 10.0f;
    public float moveSpeed = 15.0f;
    public float turnSpeed = 100.0f;
    public int ammo = 100;
    public int dashScale = 1;

    public GameObject bullet;
    public GameObject granade;

    private Transform tr;
    private Transform firePoint;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        tr = this.gameObject.GetComponent<Transform>();
        firePoint = GameObject.Find("FirePoint").GetComponent<Transform>();

        //Debug.Log($"{gameObject.name} hp: {hp}");
        //Debug.Log($"{gameObject.name} damage: {damage}");
        //Debug.Log($"{gameObject.name} speed: {moveSpeed}");
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        float m_x = Input.GetAxis("Mouse X");
        float u = 0f;

        // 좌측 쉬프트키 입력시 이동 속도 증가(대시)
        if(Input.GetKey(KeyCode.LeftShift))
        {
            dashScale = 3;
        }
        else
        {
            dashScale = 1;
        }

        // 상승(스페이스바), 하강(컨트롤)
        if(Input.GetKey(KeyCode.Space))
        {
            u = 1;
        }
        else if(Input.GetKey(KeyCode.LeftControl))
        {
            u = -1;
        }
        else{
            u = 0;
        }

        tr.Translate(h * Time.deltaTime * moveSpeed * dashScale, u * Time.deltaTime * moveSpeed * dashScale, v * Time.deltaTime * moveSpeed * dashScale);
        tr.Rotate(0, m_x * Time.deltaTime * turnSpeed, 0);

        // 마우스 왼쪽(총알), 마우스 오른쪽(유탄) 발사
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
        else if(Input.GetMouseButtonDown(1))
        {
            Instantiate(granade, firePoint.position, firePoint.rotation);
        }
    }
}
