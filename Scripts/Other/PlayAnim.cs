using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnim : MonoBehaviour {

    void onEnable () {

    }

    public void PlayVent () {

    }
    private void Update () {
        /* if (PlayerPrefs.HasKey ("pillowAnime")) {
            gameObject.GetComponent<Animator> ().enabled = false;
*/

    }
    private void OnMouseDown () {
        if (!PlayerPrefs.HasKey ("pillowAnime")) {
            gameObject.GetComponent<Animator> ().enabled = true;
            PlayerPrefs.SetInt ("pillowAnime", 1);
            StartCoroutine (waitFor1 ());

            //gameObject.GetComponent<Animator> ().enabled = false;
        }

    }
    IEnumerator waitFor1 () {
        yield return new WaitForSeconds (1);
        gameObject.GetComponent<Animator> ().enabled = false;
    }
}