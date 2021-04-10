using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


	public int health = 100; // assigning a helth value to the enemy

	public GameObject deathEffect;

	public void TakeDamage (int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			UpdateScore();
		}
	}

	private int enemyKilled = 1;

	public void UpdateScore()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
		enemyKilled++;
	}

	
   public void OnGUI()
   {
     GUI.contentColor = Color.blue;
     GUI.Box(new Rect(3, 3, 80, 30), "score: " + enemyKilled );
   }

}
