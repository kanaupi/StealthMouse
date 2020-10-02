using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//敵にプレイヤーを判別する視野を設定するスクリプト
public class Obserber : MonoBehaviour
{
    public Transform player;

    public WayPointPatrol wayPointPatrol;

    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            wayPointPatrol.DetectPlayer();
            
        }
    }

}
