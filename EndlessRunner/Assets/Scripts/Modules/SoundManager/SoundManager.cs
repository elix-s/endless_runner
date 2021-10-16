using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.SoundManager
{
    ///<summary>
    ///Менеджер загрузки и воспроизведения звуков
    ///</summary>
    public class SoundManager : MonoBehaviour
    {
        #region Public Variables

        ///<summary>
        ///Список всех звуков в игре
        ///</summary>
        [SerializeField] private List <AudioClip> _sounds = new List<AudioClip>();

        #endregion

        #region Properties
            
        public static SoundManager Instance { get; set;}
        public AudioSource SoundSource { get; set;}
            
        #endregion
    
        #region Private Methods

        public void PlaySound(string soundName, float volume)
        {      
            SoundSource.PlayOneShot(_sounds.Find(item=>item.name==soundName), volume);
        }
    
        #endregion
            
        #region MonoBehavior

        void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    
        void Start()
        {
            SoundSource = GetComponent<AudioSource>();
        }
    
        #endregion
    }
}
