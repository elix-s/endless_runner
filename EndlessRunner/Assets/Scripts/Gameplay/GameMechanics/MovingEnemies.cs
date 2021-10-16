using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace EndlessRunner.Gameplay
{
    ///<summary>
    ///Передвижение врагов, респаун
    ///</summary>
    public class MovingEnemies : MonoBehaviour
    {
        #region Private Variables

        [SerializeField] private float _speed;
        private bool _activity;
 
        #endregion
 
        #region Unity Events 
        
        void OnTriggerEnter(Collider other) {
            if(other.gameObject.name == "RespownCollider")
                transform.position = new Vector3(Random.Range(-2,2), transform.position.y, Random.Range(20,80));

            if(other.tag == "Enemies" && _activity == false)
                transform.position = new Vector3(Random.Range(-2,2), transform.position.y, Random.Range(20,80));
        }
 
        void OnBecameVisible()
        {
            _activity = true;
        }

        void OnBecameInvisible() 
        {
            _activity = false;
        }

        #endregion
        
        #region MonoBehavior
 
        void FixedUpdate()
        {   
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + GameSettings.Data.EnemiesSpeed);   
        }
 
        #endregion
    }
}
