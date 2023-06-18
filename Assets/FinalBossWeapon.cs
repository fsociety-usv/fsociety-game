using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class FinalBossWeapon : MonoBehaviour
{
	public int attackDamage = 20;
	public int enragedAttackDamage = 40;

	public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask attackMask;

	public void Attack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange / 2, attackMask);
		if (colInfo != null)
		{
			GameObject playerObject = GameObject.FindWithTag("Player");
			PlayerHealth playerHealth = playerObject.GetComponent<PlayerHealth>();
			if (playerHealth != null)
			{
				playerHealth.TakeDamage(attackDamage);
				Debug.Log("Player health: " + playerHealth.health);
			}
		}
	}

	public void EnragedAttack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange / 2, attackMask);
		if (colInfo != null)
		{
			GameObject playerObject = GameObject.FindWithTag("Player");
			PlayerHealth playerHealth = playerObject.GetComponent<PlayerHealth>();
			if (playerHealth != null)
			{
				playerHealth.TakeDamage(attackDamage);
				Debug.Log("Player health: " + playerHealth.health);
			}
		}
	}

	void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}
}