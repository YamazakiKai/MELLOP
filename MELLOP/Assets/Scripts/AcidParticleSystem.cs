using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidParticleSystem : MonoBehaviour
{
    [SerializeField] GameObject meltParticle;

    public void OnMeltIvent()
    {
        Instantiate(meltParticle.gameObject,transform,false);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
