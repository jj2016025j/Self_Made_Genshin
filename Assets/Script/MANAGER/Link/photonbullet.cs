using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class photonbullet : MonoBehaviour
{
    [SerializeField]
    float timer;
    [SerializeField]
    PhotonView pv;
    [SerializeField]
    Rigidbody rb;
    void Start()
    {
        timer = 1;
        pv = this.gameObject.GetComponent<PhotonView>();
        rb = this.gameObject.GetComponent<Rigidbody>();
        if (!pv.IsMine)
        {
            Destroy(rb);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pv.IsMine)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                PhotonNetwork.Destroy(this.gameObject);
            }
        }
    }
}
