using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish : MonoBehaviour
{
    private MeterControl meter;
    private bool isActive;

	private bool move = false;

	public float speed;

    void Start()
    {
        isActive = false;
        meter = FindObjectOfType<MeterControl>();
        GetComponentInChildren<ParticleSystem>().Stop();
    }

    void Update()
    {
        if (isActive == true)
        {
            GetComponentInChildren<ParticleSystem>().Play();

        }
        else
        {
            GetComponentInChildren<ParticleSystem>().Stop();

        }


		if(move == true)
		{
			//update objects position
			transform.Translate(0, 2 * Time.deltaTime * speed,0);

			float ranIn = Random.Range(0f, 200f);

			if(ranIn < 10)
			{
				transform.rotation = Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f));

			}

		}


    }

	public void moveJelly()
	{
		move = true;
	}
    public void shockOff()
    {
        isActive = false;
		move = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            meter.DecreaseGauge(0.05f);

            isActive = true;
        }
    }
}
