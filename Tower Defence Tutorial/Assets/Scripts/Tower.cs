using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
	[SerializeField] private GameObject range;
	[SerializeField] private LineRenderer fireLine;
    [SerializeField] private float attackSpeed = 1;
    [SerializeField] private int damage = 1;
    [SerializeField] private float attackRange = 5;
	[SerializeField] private bool isRange = false;

	public int cost = 20;

	private EnemyHealth[] target = new EnemyHealth[100];
    private float cooldown;
	private int NumEnemies = 0;

    private void Update()
    {
		//NumEnemies = 0;
		//if (target[0] == null)
            FindTarget();
        //else
            HitTarget();

		for (int i = 0; i < NumEnemies; i++) {
			if (target[i] != null){
				Vector3 h1 = target [i].transform.position - transform.position;
				h1.y = 1.2f;

			//fireLine.SetPosition (1, h1);
			}
		}
		Debug.Log (NumEnemies);
    }

    private void FindTarget()
    {
		Collider[] targets = Physics.OverlapSphere(transform.position, attackRange);
		target = new EnemyHealth[targets.Length];

        for (int i = 0; i < targets.Length; i++)
        {
            EnemyHealth tempTarget = targets[i].GetComponent<EnemyHealth>();

			if (tempTarget == null)
				continue;

			if (target[NumEnemies] == null)
            {
				target[NumEnemies] = tempTarget;
				if (isRange) {
					NumEnemies++;

				}
                continue;
            }

            float tempDistance = Vector3.Distance(transform.position, tempTarget.transform.position);
			float distance = Vector3.Distance(transform.position, target[NumEnemies].transform.position);

            if(tempDistance < distance)
            {
				target[NumEnemies] = tempTarget;
				if (isRange) {
					NumEnemies++;

				}
            }


        }




		//target = new EnemyHealth[targets.Length];
		//target = tTarget;


    }

    private void HitTarget()
    {
		for (int i = 0; i <= NumEnemies; i++)
		{
			if (target[i] != null) {
				if (cooldown <= 0.0f) {
					target [i].TakeDamage (damage);
					cooldown = attackSpeed;
				}
			}
		}

        cooldown -= Time.deltaTime;
    }
}
