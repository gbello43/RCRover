using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public Vector3 pointA;
    public Vector3 pointB;
	public Vector3 pointC;

    private Vector3 newPosition;
    bool moveForward;
    bool stay;
    bool moveBack;



    public float smooth = 3.5f;


    // Start is called before the first frame update
    void Start()
    {
        stay = true;
        moveForward = false;
        moveBack = false;

        newPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
		
		if (transform.position == newPosition)
		{
			
		}
        else
        {
            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * smooth);

        }

    }


    public void forward()
    {
		
        newPosition = pointB;
    }
    public void back()
    {
        newPosition = pointA;
		Debug.Log("pointA");

    }
	public void moveToScreen()
	{
		transform.position = pointC;
		newPosition = pointC;
	}
	public void restartEngine(){
		StartCoroutine("startEngine");

	}
	IEnumerator startEngine(){
		forward();

		yield return new WaitForSeconds(3.6f);
		Debug.Log("Start Engine");
		FindObjectOfType<NewBehaviourScript>().setMoveSpeed(17.0f);
	}
}
