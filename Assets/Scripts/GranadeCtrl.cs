using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeCtrl : MonoBehaviour
{
    public float power = 500.0f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3(0, power, power*1.5f));
    }

    private void OnCollisionEnter(Collision other) {
        Destroy(gameObject);
    }
}
