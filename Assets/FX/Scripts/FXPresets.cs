using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXPresets : MonoBehaviour {

    [SerializeField]
    private GameObject preExplodeSystem;
    [SerializeField]
    private GameObject explodeSystem;

    public ParticleSystem StartPreExplode(Vector3 position, float duration = 1f) {
        return StartParticleSystem(preExplodeSystem, position, duration);
    }

    public ParticleSystem StartExplode(Vector3 position, float duration = 1f) {
        return StartParticleSystem(explodeSystem, position, duration);
    }

    public ParticleSystem StartParticleSystem(GameObject particleSystem, Vector3 position, float duration = 1f) {
        var system = Instantiate(particleSystem);
        system.transform.position = position;
        ParticleSystem systemComponent = system.GetComponent<ParticleSystem>();
        systemComponent.Stop();
        var main = systemComponent.main;
        main.duration = duration;
        systemComponent.Play();

        return systemComponent;
    }

}