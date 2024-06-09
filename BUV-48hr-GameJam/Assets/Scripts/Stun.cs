using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : MonoBehaviour
{
    [SerializeField] KeyCode stunKey = KeyCode.Space; // Define the key to stun the shark
    [SerializeField] float stunDuration = 3f; // Adjust the stun duration as needed
    [SerializeField] Shark sharkScript; // Reference to the Shark script
    [SerializeField] UpgradeScriptableObject SO_Upgrades; // Reference to the ScriptableObject containing stun data

    private bool isStunned = false;

    private void Update()
    {
        if (Input.GetKeyDown(stunKey) && !isStunned && SO_Upgrades.numOfProtection > 0)
        {
            StartCoroutine(StunCoroutine());
        }
    }

    private IEnumerator StunCoroutine()
    {
        isStunned = true;
        sharkScript.enabled = false; // Disable the Shark script temporarily
        SO_Upgrades.numOfProtection--; // Decrease stun count
        yield return new WaitForSeconds(stunDuration);
        sharkScript.enabled = true; // Re-enable the Shark script after stun duration
        isStunned = false;
    }
}
