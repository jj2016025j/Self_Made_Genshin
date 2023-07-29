using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����ǰe���������޿�
public class Portal : MonoBehaviour
{
    public PortalScene destinationScene; // �ؼг���

    private bool playerInRange; // ���a�O�_�b�ǰe���d��

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("���a�i�J"+ destinationScene.ToString()+"�ǰe���d��C");
            Debug.Log("���UF��ǰe��"+ destinationScene.ToString());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("���a���}�ǰe���d��C");
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            if (GameManager.Instance == null)
            {
                Debug.Log("GameManager.Instance is null");
                return;
            }
            Debug.Log("���UF��A���b�ǰe���a��" + destinationScene.ToString() + "...");
            GameManager.Instance.TeleportPlayer(destinationScene);
        }
    }
}
