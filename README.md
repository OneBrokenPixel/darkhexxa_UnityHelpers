DarkHexxa Unity Helper Scripts
============
Using Simple Pool
=========
Create Pool Method 1
--------
In Unity create an empty game object and Add Component DarkHexxa->SimplePool->Pool

Under data:
  - Prefab – the game object to be cloned.
  - Max Count – the maximum number of game object this pool can spawn. 0 = infinite (not really).
  - Batch Create Count – the number of objects that will be created when the pool requires more game objects.
  - Cull Inactive – starts a coroutine that will periodically cull the inactive objects.
  - Cull Interval – the time period in seconds of the cull events.

Create Pool Method 2
-----------
In a C# script is possible to create/find a pool using the static functions in SimplePool.

Spawning/Despawning Objects
--------------
Once you have a SimplePool object in your script you can spawn an object in the pool by calling one of the pawn methods.
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
