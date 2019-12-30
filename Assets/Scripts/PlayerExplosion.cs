using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerExplosion : MonoBehaviour
{
    public float radius = 5.0F;
    public float power = 10.0F;

    void Awake()
    {
        StartCoroutine(LoadShop());
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
        }
    }

    private IEnumerator LoadShop()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(1);
    }
}
