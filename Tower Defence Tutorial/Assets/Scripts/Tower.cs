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

	private LineRenderer[] newFireLine = new LineRenderer[1000];

    private void Update()
    {
		//NumEnemies = 0;
		//if (target[0] == null)

		NumEnemies = 0;
			


        FindTarget();


		if (isRange)
			for (int i = NumEnemies; i < 1000; i++)
				if (newFireLine [i] != null)
					Destroy(newFireLine [i]);
				
        HitTarget();


		//LineRenderer[] newFireLine = new LineRenderer[NumEnemies];
		for (int i = 0; i <= NumEnemies; i++) {
			if (target [i] != null) {
				Vector3 h1 = target [i].transform.position;// - transform.position;
				h1.y = 1.2f;

				if (newFireLine [i] == null){
					newFireLine [i] = Instantiate (fireLine);
				}
				newFireLine [i].SetPosition (0, new Vector3(transform.position.x, 1.2f, transform.position.z));
				newFireLine [i].SetPosition (1, h1);
				//if (i == 0) Debug.Log (target [i].transform.position + " " + newFireLine [i].GetPosition (0) + " " + newFireLine [i].GetPosition (1));
			}
		}

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

		if (cooldown <= 0.0f) {
			for (int i = 0; i <= NumEnemies; i++) {
				if (target [i] != null) {
					target [i].TakeDamage (damage);
				}
			}

			cooldown = attackSpeed;
		}

        cooldown -= Time.deltaTime;
    }
}
