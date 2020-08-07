using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace bothash {
    public class Tiles : MonoBehaviour {

        // Start is called before the first frame update
        void Start () {

        }

        void Update () {

        }

        public void OnMouseDown () {

            /* if (MatchTheTile.Instance.firstNotPassed )
            {
                MatchTheTile.Instance.passFirstData(this.gameObject);
                MatchTheTile.Instance.firstNotPassed = false;
                IamHit = true;
            }
            else 
            {
                if (!IamHit)
                {
                    MatchTheTile.Instance.passSecondData( this.gameObject);
                    MatchTheTile.Instance.firstNotPassed = true;
                    IamHit = false;

                }
            } */
            MatchTheTile.Instance.passSecondData (this.gameObject);
        }
    }
}