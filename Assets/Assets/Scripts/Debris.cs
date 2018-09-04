using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : Hazard {

    private int velRot;

    private void Update()
    {
        RotateLikeAFuckingCrazyBoy();
    }

    private void RotateLikeAFuckingCrazyBoy() {
        transform.rotation *= new Quaternion(3 * Time.deltaTime, 0, 0, 0);
    }
}
