using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEvent : MonoBehaviour
{
    public float radius = 1.0f;
    public float MaxAngle = 40.0f;
    public float weaponDamage = 20.0f;

    public GameObject model;

    public void AttackCheck()
    {
        Collider[] collider = Physics.OverlapSphere(model.transform.position, radius, LayerMask.GetMask("Enemy"));
        if (collider.Length == 0)
        {
            return;
        }
        for (int i = 0; i < collider.Length; i++)
        {
            Vector3 v3 = collider[i].gameObject.transform.position - model.transform.position;
            Vector3 forward = model.transform.forward;
            float angel = Vector3.Angle(v3, forward);
            if (angel < MaxAngle)
            {

               
                collider[i].gameObject.GetComponent<EnemyControl>().takedamage(weaponDamage);


            }
        }
    }
}
       

