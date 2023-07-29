using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class photoncontroll : MonoBehaviour
{
    [SerializeField]
    Transform _transform;
    [SerializeField]
    PhotonView _photonView;
    [SerializeField]
    playercontrollvariablejoystick2 playercontrollvariablejoystick;
    [SerializeField]
    float speed;
    [SerializeField]
    float bulletPower;
    void Start()
    {
        _transform = this.transform;
        _photonView = this.gameObject.GetComponent<PhotonView>();
        playercontrollvariablejoystick = transform.GetComponent<playercontrollvariablejoystick2>();
        if(!_photonView.IsMine)
        {
            Destroy(this);
        }
        speed = 1;
        bulletPower = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (_photonView.IsMine)
        {
            playercontrollvariablejoystick.PlayerControl();
            Control();
        }
    }
    void Control()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 offset = new Vector3(1, 0, 0);
            GameObject bulletObj = PhotonNetwork.Instantiate("PhotonBullet",transform.position+ offset, Quaternion.identity);
            Rigidbody brb = bulletObj.GetComponent<Rigidbody>();
            brb.AddForce(new Vector3(bulletPower, 0));
        }
    }
}
