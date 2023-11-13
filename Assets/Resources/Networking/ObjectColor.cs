using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace RVC {

public class ObjectColor : Object {
    
    public ObjectColor () {
        r = 0.0f ;
        g = 0.0f ;
        b = 0.0f ;
    }
    public ObjectColor (float r, float g, float b) {
        this.r = r ;
        this.g = g ;
        this.b = b ;
    }
    public float r ;
    public float g ;
    public float b ;

}

}