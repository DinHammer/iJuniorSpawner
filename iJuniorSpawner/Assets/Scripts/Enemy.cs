using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
       public void Spawn(Vector3 position)
       {
              Instantiate(this, position, Quaternion.identity);
       }
}
