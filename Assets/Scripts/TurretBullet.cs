
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TurretBullet : MonoBehaviour
{

    private Transform target;
    [SerializeField] float speed = 70f;
    [SerializeField] float explosionRage = 0f;
    [SerializeField] GameObject vfxHit;
    public void Seek(Transform _target) { target = _target; }
    // Update is called once per frame
    void Update()
    {
        if(target ==  null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }


    void HitTarget()
    {
        GameObject _vfxGO = Instantiate(vfxHit, transform.position, transform.rotation);
        Destroy(_vfxGO,2f);

        if(explosionRage > 0f)
        {
            Explosion();
        }
        else
        {
            Damage(target);
        }
       
        Destroy(gameObject);
    }

    void Explosion()
    {
       Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRage);
        foreach(Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    void Damage(Transform enemy)
    {
         Destroy(enemy.gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, explosionRage);
    }
}
