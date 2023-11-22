using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputePositionDecision 
{
    static private int nbrUser = 0;

    static public void plusUser() { nbrUser++;  }

    static public void minusUser() { nbrUser--;}

    static public int getNbrUser() { return nbrUser; }
}
