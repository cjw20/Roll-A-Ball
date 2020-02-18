using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position; //calculates camera offset from player
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;  //updates camera position so that the offset remains constant
    }
}
