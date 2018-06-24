using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	[SerializeField] private int maxHealth = 2;
	[SerializeField] private GameObject HP;

    private int currentHealth;
	private float startHelth;

    private void Awake()
    {
        currentHealth = maxHealth;
		startHelth = HP.transform.localScale.z;
    }

    public void TakeDamage(int count)
    {
        currentHealth = Mathf.Max(currentHealth - count, 0);
		HP.transform.localScale -= new Vector3(0.0f, 0.0f, startHelth * (currentHealth * 100 / maxHealth) / 100);

        if (currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
		TowerBuilder.Instance.AddCoins (5);
    }
}
