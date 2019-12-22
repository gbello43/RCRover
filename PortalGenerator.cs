using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGenerator : MonoBehaviour {

	public ObjectPooler portalPool;
	public ObjectPooler exitPortalPool;

	public void SpawnPortal(Vector3 startPosition){

		GameObject portal = portalPool.GetPooledObject ();

		portal.transform.position = startPosition;

		portal.SetActive (true);

		portal.GetComponent<PortalTeleporter>().playParticles();

	}

	public void spawnExitPortal(Vector3 exitPosition)
	{
		GameObject exitPortal = exitPortalPool.GetPooledObject();

		exitPortal.transform.position = exitPosition;

		exitPortal.SetActive(true);

		exitPortal.GetComponent<PortalTeleporter>().playParticles();

	}
}
