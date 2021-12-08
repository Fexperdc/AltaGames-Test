using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class SphereShooting : MonoBehaviour {

    [SerializeField]
    private float _proportionMultiplier;
    [SerializeField]
    private float _preShootingSpeed;
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private Vector3 _velocity;
    [SerializeField]
    private Transform _bulletSpawnTransform;

    private SphereCollider _sphereCollider;
    public SphereCollider SphereCollider {
        get {
            if(_sphereCollider == null) {
                _sphereCollider = GetComponent<SphereCollider>();
            }
            return _sphereCollider;
        }
    }
    private Bullet _bulletInstance;
    private Vector3 _startScale = Vector3.one;

    public void PreShooting() {
        if(_bulletInstance == null) {
            _bulletInstance = Instantiate(_bullet).GetComponent<Bullet>();
            _bulletInstance.SetPositionFreeze(true);
            _bulletInstance.transform.position = _bulletSpawnTransform.position;
        }
        _bulletInstance.Power += _preShootingSpeed * Time.deltaTime;
        transform.localScale = (transform.localScale - ((Vector3.one * _bulletInstance.Power) * (_preShootingSpeed * Time.deltaTime)));
    }

    public void Shoot() {
        _bulletInstance.SetPositionFreeze(false);
        _bulletInstance.AddImpulse(_velocity);
        ResetShooting();
    }

    public void ResetShooting() {
        _bulletInstance = null;
    }

}
