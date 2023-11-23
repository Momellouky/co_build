using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UserList : MonoBehaviour
{
    private static Dictionary<int, string> usersList = new Dictionary<int, string>();
    private static UserList instance;

    //public UserList() 
    //{
    //    if (usersList == null) 
    //    {
    //        usersList = new Dictionary<int, string>();
    //    }
    //}
    //public static UserList Instance
    //{
    //    get
    //    {
    //        // If the instance is null, create a new instance
    //        if (instance == null)
    //        {
    //            instance = new UserList();
    //        }
    //        return instance;
    //    }
    //}
    public static void pushUser(int id, string name) {
        if (!usersList.ContainsKey(id)) 
        {
            Debug.Log($"Adding a user {id} , {name}");
            usersList[id] = name;
        }
    }

    public static void popUser(int id) 
    {
        if(usersList.ContainsKey(id)) 
        {
            Debug.Log($"Removing a user {id}"); 
            usersList.Remove(id);
        }
    }

    public static Dictionary<int, string> getList() {
        Debug.Log("In GetList function.");
        Debug.Log($"The size of the user list {usersList.Count}");
        return usersList;
    }
}
