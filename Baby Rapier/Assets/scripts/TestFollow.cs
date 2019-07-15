using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFollow : MonoBehaviour {

    public Transform Player;
    public float DelayFollow;
    [SerializeField]
    float vertExtent;
    [SerializeField]
    float horzExtent;
    [SerializeField]
    float maxvertExtent;
    [SerializeField]
    float maxhorzExtent;

    private Vector3 Vel = Vector3.zero;
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) >= 2)
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(Player.position.x, Player.position.y - 1, transform.position.z), ref Vel, DelayFollow);
        }
        Vector3 Temp = transform.position;
        Temp.x = Mathf.Clamp(Temp.x, horzExtent, maxhorzExtent - horzExtent);
        Temp.y = Mathf.Clamp(Temp.y, vertExtent, maxvertExtent - vertExtent);
        Temp.z = transform.position.z;
        transform.position = Temp;
    
    }
}
