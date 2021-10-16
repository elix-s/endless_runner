using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EndlessRunner;
 
namespace EndlessRunner.Gameplay
{
    ///<summary>
    ///Передвижение частей уровня
    ///</summary>
    public class TrackPartsMoving : MonoBehaviour
    { 
        #region MonoBehavior
 
        private void FixedUpdate() {
            transform.Translate(0.0f, 0.0f, GameSettings.Data.BasicSpeed);
        }
 
        #endregion
    }
}
