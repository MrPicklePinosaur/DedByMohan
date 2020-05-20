﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    public Animator aniMan;
    
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Character" && aniMan.GetBool("isAttacking") && !aniMan.GetBool("Hit"))
        {
            GameObject character = collisionInfo.collider.gameObject;
            
            character.GetComponent<PlayerDamageReceiver>().Hit();
            aniMan.SetBool("Hit", true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
