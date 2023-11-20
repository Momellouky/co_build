using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RVC; 


public class GrabableHandle : Grabable
{
    public override void LocalRelease()
    {

        if (caught)
        {

            base.LocalRelease();

            transform.localPosition = new Vector3(0, 0, 0);

            transform.localRotation = Quaternion.identity;

            rb.isKinematic = true; 

        }

    }
}
