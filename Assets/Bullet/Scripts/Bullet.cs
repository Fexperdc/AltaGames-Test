using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour {

    [SerializeField]
    private FXPresets _fxPresets;

    private float _power;
    public float Power {
        set {
            _power = value;
            transform.localScale = Vector3.one * value;
        }
        get {
            return _power;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.TryGetComponent(out Bush bush)) {
            Collider[] colliders = Physics.OverlapSphere(transform.position, GetRadiusByPower());
            foreach(Collider collider in colliders) {
                if(collider.TryGetComponent(out Bush bushObject)) {
                    bushObject.Explode(1);
                    Destroy(gameObject);
                }
            }
        }
    }

    public void AddImpulse(Vector3 velocity) {
        GetComponent<Rigidbody>().AddForce(velocity, ForceMode.Impulse);
    }

    public void SetPositionFreeze(bool freeze) {
        if(freeze == true) {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        } else {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }

    public float GetRadiusByPower() {
        return Power * 2;
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, GetRadiusByPower());
    }
}
