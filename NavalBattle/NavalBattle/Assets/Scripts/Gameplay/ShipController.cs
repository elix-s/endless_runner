using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NavalBattle.UI;
using Modules.SoundManager;
 
namespace NavalBattle.Gameplay
{
    ///<summary>
    ///Перемещение кораблей, их взрыв при касании ракеты, респаун в рандомную точку
    ///</summary>
    public class ShipController : MonoBehaviour
    {
        private Vector2 _startPosition;
        private Animator _animator;
        private float _speed;
        private bool _shipCollision;

        ///<summary>
        ///Респаун в рандомную точку
        ///</summary>
        private void Respown()
        {
            if(_startPosition.x > 0)
                transform.position = new Vector2(Random.Range(-GameSettings.Data.BorderLeft, _startPosition.x), Mathf.Round(Random.Range(GameSettings.Data.BorderTop, GameSettings.Data.BorderBottom)));
            else
                transform.position = new Vector2(Random.Range(GameSettings.Data.BorderLeft, _startPosition.x), Mathf.Round(Random.Range(GameSettings.Data.BorderTop, GameSettings.Data.BorderBottom))); 
        }

        void OnBecameInvisible()
        {
            Respown();
        }

        void OnTriggerEnter2D(Collider2D other) {
            if(other.tag == "Rocket")
            {
                StartCoroutine(Damage());
            }

            if(other.tag == "Ship")
            {
                _shipCollision = true;
                StartCoroutine(Damage());
                _shipCollision = false;
            }      
        }

        ///<summary>
        ///Действия при взрыве
        ///</summary>
        private IEnumerator Damage()
        {
            _animator.SetFloat("Damage", 0.01f);
            SoundManager.Instance.PlaySound("Explosion57", 0.4F);

            if(_shipCollision == false)
            {
                ShipDestroyedCounter counter = FindObjectOfType<ShipDestroyedCounter>();
                GameObject counterText = counter.gameObject;
                counterText.GetComponent<ShipDestroyedCounter>().Counter();
            }

            yield return new WaitForSecondsRealtime(0.5f);
            Respown();
            _animator.SetFloat("Damage", 0.0f);

        }

        void FixedUpdate()
        {
            transform.Translate(Vector3.right * Time.deltaTime * _speed, Space.World);
        }

        void Start() {
            _animator = GetComponent<Animator>();
            _startPosition = (Vector2)transform.position;
            
            if(_startPosition.x > 0)
                _speed = -GameSettings.Data.ShipSpeed;
            else
                _speed = GameSettings.Data.ShipSpeed;
        }  
    }
}
