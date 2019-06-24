using Combat.Stats;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	public float playerHealth = 1000f;

	float damageTaken;

	private void Update()
	{
		if (playerHealth <= 0f)
		{
			Destroy(gameObject);  
			//TODO add death animations
		}

		
	}

	public void RegisterDamage()
	{
		BossAttack bossAttack = GameObject.FindWithTag("Boss").GetComponent<BossAttack>();
		playerHealth = playerHealth - bossAttack.damage; //TODO Set up damage parameters
		print(playerHealth);
	}
}
