using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressableAbility : Pressable
{
    [SerializeField] protected AbilitiesCode ability;
    [SerializeField] private float damage = 5f;
    [SerializeField] private float range = 10f;
    [SerializeField] private float duration = 2f;
    
    private float timeElapsed = 0f;
    private bool isActivatingLaze = false;

    public override void Pressed()
    {
        // Activate ability for the player
        PlayerCtrl.Instance.PlayerAbility.Active(ability);
        
        // Check if the ability is Laze, then start the activation process
        if (ability == AbilitiesCode.Laze && !isActivatingLaze)
        {
            isActivatingLaze = true;
            StartCoroutine(ActivateLaze());
        }
    }

    private IEnumerator ActivateLaze()
    {
        // Reset the timer and start applying damage over time
        timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            // Update elapsed time
            timeElapsed += Time.deltaTime;

            // Apply damage to any objects in range
            RaycastHit[] hits = Physics.SphereCastAll(transform.position, range, transform.forward);

            foreach (RaycastHit hit in hits)
            {
                DamageReceiver damageReceiver = hit.collider.GetComponent<DamageReceiver>();
                if (damageReceiver != null && !damageReceiver.IsDead())
                {
                    damageReceiver.Deduct((int)damage);
                }
            }

            // Wait until the next frame before continuing
            yield return null;
        }

        // Once the duration is over, reset the flag
        isActivatingLaze = false;
    }
}
