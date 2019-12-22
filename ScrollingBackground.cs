using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {

    public float backgroundSize;
	public Sprite[] backgroundImg;
	public int layerPoint;
	public int counter = 0;

    public float zPoint;
    public float yPoint;


    public Transform cameraTransform;
    private Transform[] layers;
    public float viewZone = 10f;
    private int leftIndex;
    private int rightIndex;

    private void Start()
    {

       	//cameraTransform = cam;
        layers = new Transform[transform.childCount];

        for(int i = 0; i < transform.childCount; i++)
        {

            layers[i] = transform.GetChild(i);
        }

        leftIndex = 0;
        rightIndex = layers.Length - 1;


    }

    void Update()
    {
		
        //if the player passes a certain position then it will scroll either to the left or to the right deppending on the position of the player
         
         if(cameraTransform.position.x > (layers[rightIndex].transform.position.x - viewZone))
         {

             ScrollRight();
			 changeBackground();
         }
		if (cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone))
		{
			ScrollLeft();

		}
         
    }

    //scrolls to the left 
    private void ScrollLeft() {

        //int lastRight = rightIndex;

        layers[rightIndex].position = new Vector3(layers[leftIndex].position.x - backgroundSize, yPoint, zPoint);// Vector3.right * (layers[leftIndex].position.x - backgroundSize); //most left image - backgroundSize

        leftIndex = rightIndex;

        rightIndex--;

        if (rightIndex < 0)
        {

            rightIndex = layers.Length - 1;
        }
    }

    private void ScrollRight()
    {

        //int lastLeft = leftIndex;

        layers[leftIndex].position = new Vector3(layers[rightIndex].position.x + backgroundSize, yPoint, zPoint);//most left image - backgroundSize

        rightIndex = leftIndex;

        leftIndex++;

        if (leftIndex == layers.Length)
        {

            leftIndex = 0;
        }

    }

	void changeBackground()
	{
		//layers.length
		if(cameraTransform.position.x >= 200f && layerPoint == 1 && counter <= layers.Length)
		{
			int activeCam = FindObjectOfType<cameraManager>(). getActive();

			switch(activeCam)
			{
				case 1:
					Debug.Log("ActiveBackground: " + activeCam);
					layers[rightIndex].GetComponent<SpriteRenderer>().sprite = backgroundImg[0];
					counter++;
					//increase counter size of layers.Length
					break;
				Default:
					break;
			}
		}
		//this.gameObject.GetComponent<SpriteRenderer>().sprite = backgroundImg[0];
	}
}
