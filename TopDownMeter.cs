using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TopDownMeter : MonoBehaviour {

    public GameObject[] charges;
    public GameObject portalButton;
    public GameObject portal;

    private int currentInd;
    private int currentLevel;

    private int[] tdChecks = new int[3];

    // Use this for initialization
    void Start ()
    {
        for (int i = 0; i < charges.Length; i++)
            charges[i].SetActive(false);
        portalButton.SetActive(false);
        currentInd = 0;
    }

    public void ChargePickedUp()
    {
        if (tdChecks[2] == 1)
            return;
        if (tdChecks[0] == 1)
        {
            if (tdChecks[1] == 1)
            {
                if (tdChecks[2] == 0)
                    ActivateSlot3();
            }
            else
                ActivateSlot2();
        }
        else
            ActivateSlot1();
    }   // Called on collision, decides what slot to activate

    public void PortalOpened()
    {
        DeactivateAll();
        SpawnPortal();
    }   // Called on user button select 

    private void ActivateSlot1()
    {
        Debug.Log("Slot1 Activated");
        tdChecks[currentInd] = 1;
        charges[currentInd].SetActive(true);
        currentInd++;
    }   //

    private void ActivateSlot2()
    {
        tdChecks[currentInd] = 1;
        charges[currentInd].SetActive(true);
        currentInd++;
    }   // 
    
    private void ActivateSlot3()
    {
        tdChecks[currentInd] = 1;
        charges[currentInd].SetActive(true);
        portalButton.SetActive(true);
    }   //

    private void SpawnPortal()
    {
        GameObject port;
        Vector3 playerRef;
        port = Instantiate(portal) as GameObject;
        playerRef = GameObject.FindGameObjectWithTag("Player").transform.position;
        port.transform.position = new Vector3(playerRef.x, playerRef.y, playerRef.z + 30.0f);
    }

    private void DeactivateAll()
    {
        for (int k = 0; k < tdChecks.Length; k++)
        {
            tdChecks[k] = 0;
            charges[k].SetActive(false);
        }

        portalButton.SetActive(false);
        currentInd = 0;
    }   //
}
