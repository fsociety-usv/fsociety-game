using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public enum TeamIndex : sbyte
{
    None = -1,
    Neutral = 0,
    Player,
    Enemy,
    Count
}


public class TeamComponent : MonoBehaviour
{

    public int health = 50;

    public Animator animator;

    [SerializeField] private TeamIndex _teamIndex = TeamIndex.None;
    public TeamIndex teamIndex
    {
        set
        {
            if (_teamIndex == value)
            {
                return;
            }

            _teamIndex = value;
        }
        get { return _teamIndex; }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            animator.SetBool("death", true);
            Invoke("Despawn", 3f); // Delayed despawn after 3 seconds
        }
    }

    private void Despawn()
    {
        // Destroy the enemy object after the delay
        Destroy(gameObject);
    }
}
