using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour 
{
	public GameObject explosion;		// Prefab of explosion effect.
    public bool isSuper = false;

	void Start () 
	{
		// Destroy the rocket after 2 seconds if it doesn't get destroyed before then.
		Destroy(gameObject, 2);
	}


	void OnExplode()
	{
		// Create a quaternion with a random rotation in the z-axis.
		Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

		// Instantiate the explosion where the rocket is with the random rotation.
		Instantiate(explosion, transform.position, randomRotation);
	}
	
	void OnTriggerEnter2D (Collider2D col) 
	{
        // if the player shoots a player...
        if (col.gameObject.tag == "Player")
        {
            //if the target's shield is down and/or this is a Super Rocket
            if (col.GetComponent<PlayerControl>().shielded == false || isSuper == true)
            {
                Debug.Log("Hit Player");
                // Find all of the colliders on the gameobject and set them all to be triggers.
                Collider2D[] cols = col.GetComponents<Collider2D>();
                foreach (Collider2D c in cols)
                {
                    c.isTrigger = true;
                }

                // Move all sprite parts of the player to the front
                SpriteRenderer[] spr = GetComponentsInChildren<SpriteRenderer>();
                foreach (SpriteRenderer s in spr)
                {
                    s.sortingLayerName = "UI";
                }

                // ... disable user Player Control script
                col.GetComponent<PlayerControl>().enabled = false;

                // ... disable the Gun script to stop a dead guy shooting a nonexistant bazooka
                col.GetComponentInChildren<Gun>().enabled = false;

                // ... Trigger the 'Die' animation state
                col.GetComponent<Animator>().SetTrigger("Die");

                OnExplode();
                Destroy(gameObject);
            }
            else
            {
                OnExplode();
                Destroy(this.gameObject);
            }
        }
        //If the rocket hits anything but the player, rocket explodes
        else
        {
            OnExplode();
            Destroy(this.gameObject);
        }
	}
}
