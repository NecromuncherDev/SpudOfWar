using UnityEngine;
using System.Collections;

public class PickupSpawner : MonoBehaviour
{
	public GameObject[] pickups;				// Array of pickup prefabs with the bomb pickup first and health second.
	public float pickupDeliveryTime = 6f;		// Delay on delivery.
	public float dropRangeLeft;					// Smallest value of x in world coordinates the delivery can happen at.
	public float dropRangeRight;				// Largest value of x in world coordinates the delivery can happen at.



	void Start ()
	{
        StartCoroutine(DeliverPickup());
	}

    public IEnumerator DeliverPickup()
	{
        while (true)
        {
            Debug.Log("Spawning Crate");
            // Wait for the delivery delay.
            yield return new WaitForSeconds(pickupDeliveryTime);

            // Create a random x coordinate for the delivery in the drop range.
            float dropPosX = Random.Range(dropRangeLeft, dropRangeRight);

            // Create a position with the random x coordinate.
            Vector3 dropPos = new Vector3(dropPosX, 15f, 1f);
            Instantiate(pickups[0], dropPos, Quaternion.identity);
        }
		
	}
}
