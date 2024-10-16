using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] int speed = 10;
    [SerializeField] Health healthScript;
    [SerializeField] int damage;
    [SerializeField] int TimeBetweenDamage;

    private bool attacked;

    private void Update()
    {
        var step = speed * Time.deltaTime;
        gameObject.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);

        var direction = (player.transform.position - transform.position).normalized;
        var targetRotation = Quaternion.LookRotation(direction);

        // Add 90 degrees to the y-axis
        targetRotation *= Quaternion.Euler(0, 90, 0);

        transform.rotation = targetRotation;
        transform.rotation = targetRotation;

        if (Vector3.Distance(transform.position, player.transform.position) < 2 && !attacked)
        {
            healthScript.TakeDamage(damage);
            StartCoroutine(SetBoolToFalseAfterDelay());
            attacked = true;
            //damage the player
        }
    }
    IEnumerator SetBoolToFalseAfterDelay()
    {
        // Wait for 1 second
        yield return new WaitForSeconds(TimeBetweenDamage);
        // Set the boolean to false
        attacked = false;
    }
}
