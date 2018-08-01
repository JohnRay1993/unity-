using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
	public enum ObjectType
	{
		Building, Unit
	}

	public enum AbilityType
	{
		Spawn, Build
	}

	[SerializeField]
	public struct Ability
	{
		public AbilityType Type;
		public GameObject Argument;
	}

	public class ObjectInfo : MonoBehaviour
	{

			public string Name;
			public int MaxHealth;
			public int CurrentHealth;//{ get; set; }
			public string healthText;

			


			[SerializeField] public Ability[] Abilities;

			private void Start()
			{
				//CurrentHealth = MaxHealth;
				healthText = CurrentHealth.ToString () + "/" + MaxHealth.ToString ();
			}

	}
}
