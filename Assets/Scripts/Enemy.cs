using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp = 100.0f;
    public float damage = 10.0f;
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"{gameObject.name} hp: {hp}");
        Debug.Log($"{gameObject.name} damage: {damage}");
        Debug.Log($"{gameObject.name} speed: {speed}");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
