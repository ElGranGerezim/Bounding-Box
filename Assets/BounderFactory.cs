using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounderFactory:MonoBehaviour {
    [SerializeField] GameObject template;
    public void SpawnBounder () {
        Instantiate(template);
    }
}
