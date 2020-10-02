using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//敵にプレイヤーを判別する視野を設定するスクリプト
public class Obserber : MonoBehaviour
{
    public Transform player;
    bool isPlayerInRange;

    private void Update()
    {
        //プレイヤーが範囲内にいるときにRayで途中に壁などがないか検知
        if (isPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {

                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            isPlayerInRange = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            isPlayerInRange = false;
        }
    }
}
