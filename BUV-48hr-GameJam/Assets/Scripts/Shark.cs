using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shark : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] int speed = 10;

    private void Update()
    {
        var step = speed * Time.deltaTime;
        gameObject.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);

        var direction = (player.transform.position - transform.position).normalized;
        var targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = targetRotation;

        if (Vector3.Distance(transform.position, player.transform.position) < 0.001f)
        {
            //damage the player
        }
    }
}
