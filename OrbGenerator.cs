using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbGenerator : MonoBehaviour {

    public ObjectPooler OrbPool;

	private Vector2 direction = new Vector2(0, -1);

	/*
	public void SpawnOrbs(Vector2 startPosition, int amount)
	{
		float distanceBetweenOrbs = 0;

		for(int i =0; i < amount; i++)
		{
			RaycastHit2D hit = Physics2D.Raycast(new Vector2(startPosition.x + distanceBetweenOrbs, startPosition.y),direction, 7f);
			GameObject orb = OrbPool.GetPooledObject();

			orb.transform.position = new Vector2(hit.point.x, hit.point.y + 2f);
			orb.SetActive(true);
			distanceBetweenOrbs += 3f;

		}

	}
	*/
    // Use this for initialization
   	public void SpawnOrbs(Vector2 startPosition, int amount) 
	{
		float distanceBetweenOrbs = 0;
		int count =0;

		Debug.Log("OrbStart: " + startPosition);

		for (int i = 0; i < amount; i++) {
			
			GameObject orb = OrbPool.GetPooledObject ();

			RaycastHit2D hit = Physics2D.Raycast (new Vector2 (startPosition.x + distanceBetweenOrbs, startPosition.y), direction, 20f);

				Debug.Log("Hit: " + hit.point.x + ", " + hit.point.y);

				orb.transform.position = new Vector2 (hit.point.x, hit.point.y + 2f);

				Debug.Log("OrbP: " + orb.transform.position);

				orb.SetActive (true);

				distanceBetweenOrbs += 3f;

				count++;

				
		}
		Debug.Log("Count: " + count);
    }
	public void SpawnShards(Vector2 startPosition, int amount) 
	{
		float distanceBetweenOrbs = 0;
		int count =0;

		Debug.Log("ShardStart: " + startPosition);

		for (int i = 0; i < amount; i++) {

			GameObject orb = OrbPool.GetPooledObject ();

			RaycastHit2D hit = Physics2D.Raycast (new Vector2 (startPosition.x + distanceBetweenOrbs, startPosition.y), direction, 20f);

			Debug.Log("Hit: " + hit.point.x + ", " + hit.point.y);

			orb.transform.position = new Vector2 (hit.point.x, hit.point.y + 2f);

			Debug.Log("SharP: " + orb.transform.position);

			orb.SetActive (true);

			distanceBetweenOrbs += 3f;

			count++;


		}
		Debug.Log("Count: " + count);
	}
}

