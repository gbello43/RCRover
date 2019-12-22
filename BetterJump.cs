using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour {

    public float fallMultiplier;
    public float lowJumpMultiplier;

	public MeterControl meter;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    
    void FixedUpdate()
    {
        if (rb.velocity.y < 0)
        {
			
            rb.gravityScale = fallMultiplier;

        }
		else if (rb.velocity.y > 0 && !Input.GetMouseButton(0))
        {
            rb.gravityScale = lowJumpMultiplier;

        }
        else {

            rb.gravityScale = 1;
        }
    }
}
