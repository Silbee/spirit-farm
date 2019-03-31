using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendPodScript : MonoBehaviour
{
    public GameObject friendPod;

    void Start()
    {
        
    }

    void Update()
    {
       if (Input.GetMouseButton(0))
        {
            friendPod.SetActive(true);
        }
    }

}
