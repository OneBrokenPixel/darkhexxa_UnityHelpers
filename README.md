DarkHexxa Unity Helper Scripts
============

[Doxygen Documents](http://darkhexxa.github.io/darkhexxa_UnityHelpers/doc/html/index.html)

Using Simple Pool
=========
Create Pool Method 1
--------
Create an empty GameObject and add component DarkHexxa->SimplePool->Pool

In the SimplePool Component you have access to the following settings under data:
  - Prefab – the game object to be cloned.
  - Max Count – the maximum number of game object this pool can spawn. 0 = unlimited.
  - Batch Create Count – the number of objects that will be created when the pool requires more game objects.
  - Cull Inactive – starts a coroutine that will periodically cull the inactive objects.
  - Cull Interval – the time period in seconds between cull events.

Create Pool Method 2
-----------
In a C# script it is possible to create/find a pool using the static functions in SimplePool.

```sh
public static SimplePool FindPoolFor(GameObject prefab)
public static System.Collections.Generic.IEnumerable<SimplePool> FindAllPoolsFor(GameObject prefab)
```
Returns a pool or a list of pools that generate the prefabs provided.

```sh
public static SimplePool FindPoolFor(PoolData data)
public static System.Collections.Generic.IEnumerable<SimplePool> FindAllPoolsFor(PoolData data)
```
Returns a pool or a list of pools that match PollData object provided. The PoolData object contains the settings for the SimplePool.
```sh
public static SimplePool CreatePool(GameObject prefab)
public static SimplePool CreatePool(GameObject prefab, int maxCount, int batchCreateCount, bool cullInactive, float cullInterval)
public static SimplePool CreatePool(string gameObjectName, GameObject prefab)
public static SimplePool CreatePool(string gameObjectName, GameObject prefab, int maxCount, int batchCreateCount, bool cullInactive, float cullInterval)
public static SimplePool CreatePool(PoolData data)
public static SimplePool CreatePool(string gameObjectName, PoolData data)       
```
Create functions look for matching Pools before they create a new pool returning either the pool that has been found or a new pool.

Spawning/Despawning Objects
--------------
Once you have a SimplePool object in your script you can spawn an object in the pool by calling one of the spawn methods.
```sh
public GameObject Spawn()
```
Returns a GameObject at the SimplePools position with its own rotation.
```sh
public GameObject Spawn( Vector3 position, Quaternion rotation )
```
Returns a GameObject at the position and with the rotation provided.

Once spawned the object can be despawned by passing the game object back with the despawn method.
```sh
public void Despawn(GameObject obj)
```
This removes the object from the active list if it is apart of this pool.

Base Pool Component
-------------------
The BasePollComponent is an abstract class that provides the following;
```sh
public SimplePool pool
```
Pool property for storing the pool that created this object.
```sh
public void OnCreatedByPool( SimplePool pool )
```
A method that is called when an object is created by a pool before being spawned. It passes in the SimplePool object so that this script can despawn its self.
```sh
public abstract void OnSpawn();
```
This abstract method is called when the object is spawned after it has become active.
```sh
public abstract void OnDespawn();
```
this is called when the object is despawned.
