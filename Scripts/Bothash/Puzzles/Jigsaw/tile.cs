using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace bothash {
    public class tile : MonoBehaviour {
        // Start is called before the first frame update
        public int randI;
        public int index;
        void Start () {

            index = int.Parse (this.gameObject.name) - 1;

        }

        // Update is called once per frame
        void Update () {

        }
        public void OnMouseDown () {
            /* Debug.Log (Jigsaw.Instance.posAfterRandom[index]);
            float tileX = Math.Abs (this.gameObject.transform.position.x);
            float tileY = Math.Abs (this.gameObject.transform.position.y);
            float blankX = Math.Abs (Jigsaw.Instance.blankTile.transform.position.x);
            float blankY = Math.Abs (Jigsaw.Instance.blankTile.transform.position.y);
            /* Debug.Log (tileY - blankY);
            Debug.Log (tileX - blankX); */
            /* Debug.Log (Math.Round (Math.Abs (tileX - blankX)));
            Debug.Log (Math.Round (Math.Abs (tileY + blankY)));
            if (Math.Round (Math.Abs (tileX - blankX)) == Math.Round (Jigsaw.Instance.constDifX, 0) && tileY - blankY == 0) {
                Debug.Log ("x");
                Vector3 temp = new Vector3 (0, 0, 0);
                temp = this.gameObject.transform.localPosition;
                this.gameObject.transform.localPosition = Jigsaw.Instance.blankTile.transform.position;
                Jigsaw.Instance.blankTile.transform.position = temp;
            } else {
                if (tileX - blankX == 0 && Math.Round (Math.Abs (tileY + blankY)) == Math.Round (Jigsaw.Instance.constDifY, 0)) {
                    Debug.Log ("y");
                    Vector3 temp = new Vector3 (0, 0, 0);
                    temp = this.gameObject.transform.localPosition;
                    this.gameObject.transform.localPosition = Jigsaw.Instance.blankTile.transform.position;
                    Jigsaw.Instance.blankTile.transform.position = temp;
                }
            }* / */
            //this.gameObject.transform.localPosition = Jigsaw.Instance.blankTile.transform.position;
            randI = Jigsaw.Instance.posAfterRandom[index];
            Debug.Log (Jigsaw.Instance.posAfterRandom[index]);
            if (randI - 1 == Jigsaw.Instance.blankPos || randI + 1 == Jigsaw.Instance.blankPos || randI + 5 == Jigsaw.Instance.blankPos || randI - 5 == Jigsaw.Instance.blankPos) {
                Debug.Log ("can swap");
                Jigsaw.Instance.posAfterRandom[index] = Jigsaw.Instance.blankPos;
                Jigsaw.Instance.blankPos = randI;
                Vector3 temp1 = new Vector3 (0, 0, 0);
                temp1 = this.gameObject.transform.localPosition;
                this.gameObject.transform.localPosition = Jigsaw.Instance.blankTile.transform.position;
                Jigsaw.Instance.blankTile.transform.position = temp1;
                Debug.Log (Jigsaw.Instance.posAfterRandom[index]);
                if (Jigsaw.Instance.checkRandompos ()) {
                    Jigsaw.Instance.ActivateBox ();
                }
            }
            if (Jigsaw.Instance.checkRandompos ()) {
                Debug.Log ("inside if");
                Jigsaw.Instance.ActivateBox ();
            }

        }
    }
}