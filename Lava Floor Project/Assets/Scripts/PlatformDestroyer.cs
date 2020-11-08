using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{

    public GameObject platform;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ObjDestroy();
    }
    private void ObjDestroy()
    {
        Destroy(platform, 5); // 5 seconds before the objects deletes itself
    }
}
