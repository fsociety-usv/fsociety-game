using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform player;

    private Vector3 initialScale;

    private void Start()
    {
        initialScale = transform.localScale;
    }

    private void Update()
    {
        LookAtPlayer();
    }

    public void LookAtPlayer()
    {
        Vector3 direction = player.position - transform.position;

        if (direction.x < 0f && transform.localScale.x > 0f)
        {
            transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
        }
        else if (direction.x > 0f && transform.localScale.x < 0f)
        {
            transform.localScale = new Vector3(initialScale.x, initialScale.y, initialScale.z);
        }
    }
}