using UnityEngine;
using System.Collections;

using Darkhexxa.SimplePool;

public class SimplePool_TestScript : MonoBehaviour {

    SimplePool[] pools;

    public GameObject prefab;
    SimplePool pool;
    // Use this for initialization
	void Start () {
        pools = FindObjectsOfType<SimplePool>();

        pool = SimplePool.CreatePool("Mine", prefab,200,10,true,10f);
	}
	
	// Update is called once per frame
	void Update () {
	
        foreach( SimplePool p in pools)
        {
            p.Spawn();
        }
        pool.Spawn();
	}
}
