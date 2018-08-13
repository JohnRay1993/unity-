using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    private int m_damage = 10;


    private void OisionEnter(Collision collision)
    {
        Debug.Log("piu");
        var hit = collision.gameObject;
        var health = hit.GetComponentInParent<Health>();
        if (health != null)
        {
            health.TakeDamage(m_damage);
        }
        Destroy(hit);
    }
}
