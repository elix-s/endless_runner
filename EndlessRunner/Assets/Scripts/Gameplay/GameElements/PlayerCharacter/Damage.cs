using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Modules.SoundManager;

namespace EndlessRunner.Gameplay 
{
    ///<summary>
    ///Взрыв кубика, события при проигрыше
    ///</summary>
    public class Damage : MonoBehaviour
    {
        #region Variables

        ///<summary>
        ///размер части кубика
        ///</summary>
        [SerializeField] private float _cubeSize;

        ///<summary>
        ///на сколько частей будет разлетаться кубик
        ///</summary>
        [SerializeField] private int _cubeInRow;
        [SerializeField] private Material _cubeMaterial;
        [SerializeField] private float _explosionPower;
        [SerializeField] private float _explosionRadius;
        [SerializeField] private float _addMass;
        [SerializeField] private GameObject _replayButton;
        [SerializeField] private GameObject _distanceTraveledText;
        [SerializeField] private GameObject _bestResultText;
        [SerializeField] private GameObject _gameTimer;
        [SerializeField] private GameObject _textLabel1;
        [SerializeField] private GameObject _textLabel2;

        #endregion

        #region priavte Methods
        
        ///<summary>
        ///взрыв куба после столкновения с препятствием
        ///</summary>
        private void Explosion()
        {
            gameObject.SetActive(false);
            SoundManager.Instance.PlaySound("Explosion59", 0.4F);

            //создание массива из кубов в цикле
            for(int x = 0; x < _cubeInRow; x++)
            {
                for(int y = 0; y < _cubeInRow; y++)
                {
                    for(int z = 0; z < _cubeInRow; z++)
                    {
                        CreatingParts(x,y,z);
                    }
                }
            }

            Vector3 explosionPosition = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPosition, _explosionRadius);

            foreach (Collider hit in colliders) 
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if(rb != null) 
                {
                    rb.AddExplosionForce(_explosionPower, transform.position, _explosionRadius);
                }
            }
        }

        ///<summary>
        ///создание элемента массива кубов
        ///</summary>
        private void CreatingParts(int x, int y, int z)
        {
            GameObject part;
            part = GameObject.CreatePrimitive(PrimitiveType.Cube);
            part.transform.position = transform.position + new Vector3(_cubeSize*x, _cubeSize*y, _cubeSize*z);
            part.transform.localScale = new Vector3(_cubeSize, _cubeSize, _cubeSize);
            part.AddComponent<Rigidbody>();
            part.GetComponent<Rigidbody>().mass = _addMass;
            part.GetComponent<MeshRenderer>().material = _cubeMaterial;
        }

        #endregion 

        #region Unity Events

        ///<summary>
        ///События при проигрыше
        ///</summary>
        void OnTriggerEnter(Collider collision)
        {
            if(collision.tag == "Enemies")
            {
                Explosion();
                GameSettings.Data.BasicSpeed = 0.0f;
                GameSettings.Data.EnemiesSpeed = 0.0f;
                GameSettings.Data.IsGameActive = false;
                _replayButton.SetActive(true);
                _distanceTraveledText.SetActive(true);
                _textLabel1.SetActive(true);
                _textLabel2.SetActive(true);
                float distanceTraveled = _gameTimer.GetComponent<GameTimer>().DistanceTraveled;
                _distanceTraveledText.GetComponent<Text>().text = Mathf.Round(distanceTraveled).ToString() + "м.";

                if(PlayerPrefs.HasKey("BestTime"))
                {
                    if(distanceTraveled > PlayerPrefs.GetFloat("BestTime"))
                        PlayerPrefs.SetFloat("BestTime", distanceTraveled);
                }
                else
                {
                    PlayerPrefs.SetFloat("BestTime", distanceTraveled);
                }

                _bestResultText.SetActive(true);
                _bestResultText.GetComponent<Text>().text = Mathf.Round(PlayerPrefs.GetFloat("BestTime")).ToString() + "м.";
            }
        }

        #endregion              
    }
}

