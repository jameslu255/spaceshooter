using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    private float damagePerHit;

    //damage is set by difficulty in PlayerController
    //values are 20, 25, 35 (1, 2 or 3 hits to die)
    //HealthBar starts at x scale of 3.
    public int TakeDamage(int damage, int totHealth)
    {
        if (damage == 20)
            damagePerHit = 0.6f;
        if (damage == 25)
            damagePerHit = .75f;
        if (damage == 35)
            damagePerHit = 1.0f;
        this.gameObject.transform.localScale -= new Vector3(damagePerHit, 0, 0);
        return 0;
    }
}
