using UnityEngine;

namespace Combat.Stats
{
	public class BossAttack : MonoBehaviour
	{
		PlayerHealth playerHP;

		public float chanceToHit;
		public float chanceToMiss;
		public float chanceToDodge;
		public float chanceToParry;
		public float chanceToCrit;

		public bool isHit;
		public bool isCrit;
		public bool dodged;
		public bool parry;

		public int damage;

		public void Awake()
		{
			
		}


		void MeasureAttack()
		{
			chanceToDodge = Random.Range(0f, 1f);		//Checks if player dodges
			if (chanceToDodge <= 0.05)
			{
				dodged = true;
			}
			else if (chanceToDodge > 0.05)
			{
				dodged = false;
			}

			chanceToParry = Random.Range(0f, 1f);		//Checks if player parrys
			if (chanceToParry <= 0.05)
			{
				parry = true;
			}
			else if (chanceToParry > 0.05)
			{
				parry = false;
			}

			chanceToHit = Random.Range(0f, 1f);		//Checks if the player hit the target
			if (chanceToHit <= 0.9f  && !dodged && !parry)
			{
				chanceToCrit = Random.Range(0f, 1f);  //Checks if the target was critcally struck
				if (chanceToCrit <= 0.33f)
				{
					isCrit = true;
				}
				else if (chanceToCrit > 0.33f)
				{
					isHit = true;
					isCrit = false;
				}
			}
			else
			{
				isHit = false;
			}

			

			
		}

		void SendAttack()
		{
			playerHP = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();

			if (isHit)
			{
				if (isCrit)
				{

				}

				damage = 50;
				playerHP.RegisterDamage();
			}
			else
			{
				//return;
			}
		}
	}
}