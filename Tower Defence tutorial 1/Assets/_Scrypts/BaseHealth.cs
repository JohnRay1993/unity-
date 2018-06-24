using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour {

	[SerializeField] private int health = 20;
	[SerializeField] private GameObject loseText;
	[SerializeField] private Gradient gradient;

	private int currentHealth;
	private MeshRenderer meshRender;

	private void Awake()
	{
		meshRender = GetComponent<MeshRenderer> ();
		currentHealth = health;
	}

	private void Start()
	{
		meshRender.material.color = Color.yellow;
		meshRender.material.color = gradient.Evaluate (0);
	}

	private void OnTriggerEnter(Collider other)
	{
		EnemyDamage enemy = other.GetComponent<EnemyDamage> ();

		if (enemy == null)
			return;

		currentHealth -= enemy.Damage;

		meshRender.material.color = gradient.Evaluate (1 - currentHealth / (float)health);

		if (currentHealth <= 0) {
			loseText.SetActive (true);
			Time.timeScale = 0;
		}
	}
}
