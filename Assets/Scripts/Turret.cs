using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
     private Transform target;    
    private float fireCoutdown = 0f;   

    [Header("Campos de funcionalidades obrigatorias")]
    [SerializeField] string enemyTag;
    [SerializeField] Transform baseToRotate;
    [SerializeField] private float speedRotation = 10;
    [SerializeField] private Transform shootPoint;

    [Header("Config padrão das balas")]
    [SerializeField] private GameObject bulletTurret;
    [SerializeField] float fireRate = 1f;
    [SerializeField] private float range = 15f;

    [Header("Config Laser Weapon")]
    [SerializeField] bool useLaser;
    [SerializeField] LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceEnemy < shortestDistance)
            {
                shortestDistance = distanceEnemy;
                nearestEnemy = enemy;
            }

        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            if (useLaser)
            {
                if(lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                }
            }
            return;
        }
        // look on target
        LookOnTarget();

        // fire
        
        if(useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCoutdown <= 0f)
            {
                Shoot();
                fireCoutdown = 1f / fireRate;
            }

            fireCoutdown -= Time.deltaTime;
        }
       
    }

    void Laser()
    {
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
        }

        lineRenderer.SetPosition(0, shootPoint.position);
        lineRenderer.SetPosition(1, target.position);
    }
    void LookOnTarget()
    {
         
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(baseToRotate.rotation, lookRotation, Time.deltaTime * speedRotation).eulerAngles;
        baseToRotate.rotation = Quaternion.Euler(0f, rotation.y, rotation.z);
    }
    void Shoot()
    {
        GameObject bulletGO =   Instantiate(bulletTurret, shootPoint.transform.position, shootPoint.transform.rotation);   
        TurretBullet bullet = bulletGO.GetComponent<TurretBullet>();

        if(bullet != null)
        {
            bullet.Seek(target);
        }

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
