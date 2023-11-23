using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveHandles
{

    public static ArrayList handleIds = new ArrayList();
    public static int activeHandles = 0; 
    public static void pushID(int viewID) 
    {
       if(! handleIds.Contains(viewID)) {
            handleIds.Add(viewID);
            activeHandles++; 
       }
    }

    public static void popID(int viewID)
    {
        if (handleIds.Contains(viewID)) 
        { 
            handleIds.Remove(viewID); 
            activeHandles--;
        }
    }

    public static int activeHandlesNumber() 
    { 
        return activeHandles;
    }

    public static bool notifyFirstActive() {
        return activeHandles == 0 ? true : false ;
    }

}
