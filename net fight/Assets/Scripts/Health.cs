using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

    [SerializeField]
    private int m_maxHealth = 100;
    private RectTransform m_healthBBar;


    //[SyncVar(hook = "OnChangeHealth")]
    [SyncVar]
    private int m_currentHealth;

	// Use this for initialization
	void Start () {
        m_currentHealth = m_maxHealth;
	}


    public void TakeDamage(int amount)
    {
        if (!isServer)
            return;
        
        m_currentHealth -= amount;
        if (m_currentHealth <= 0)
            Debug.Log("you died!");
    }
	
    //private void OnChangeHealth()
    //{
        
    //}
}
