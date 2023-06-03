using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    // Variables
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get pivot point z value
        float pivotPointZ = transform.parent.rotation.eulerAngles.z;

        // If the z value is above 90 or below -90, flip the gun about the y axis
        if (pivotPointZ > 90 & pivotPointZ < 270)
        {
            spriteRenderer.flipY = true;
        }
        else if (pivotPointZ <= 90 | pivotPointZ >= 270)
        {
            spriteRenderer.flipY = false;
        }
    }
}
