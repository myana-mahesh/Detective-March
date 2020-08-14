using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigate : MonoBehaviour {

	/* MousePointer myPointer;
	_RoomManager roomManager;

	public GameObject myCurrentScreen;
	public GameObject myDownScreen;

	public GameObject dialogues;
	public GameObject nextButton;

	public int roomNumber;
	public float duration;

	public GameObject blockScreen2D;
	public GameObject blockScreen3D;

	void Start () {

		myPointer = GameObject.FindGameObjectWithTag("Main").GetComponent<MousePointer>();
		roomManager = GameObject.FindGameObjectWithTag("AllRooms").GetComponent<_RoomManager>();
	}

/*	void OnMouseEnter()
	{
		myPointer.SetDownPointer();
	}
*/
	/*void OnMouseDown()
	{
		blockScreen2D.SetActive (true);
		blockScreen3D.SetActive (true);
		StartCoroutine ("WaitFor3Seconds");
	}

	IEnumerator WaitFor3Seconds() {
		yield return new WaitForSeconds(duration);
        myDownScreen.SetActive(value: true);
		myCurrentScreen.SetActive(value: false);
		dialogues.SetActive(value: false);
		nextButton.SetActive(value:false);
		blockScreen2D.SetActive (false);
		blockScreen3D.SetActive (false);
		roomManager.ChangeRoom(roomIndex: roomNumber);
    }*/
	/*
		void OnMouseExit()
		{
			myPointer.SetNormalPointer();
		}
	*/
	/*public void OnMouseRelease()
	{
		myPointer.SetNormalPointer();
		dialogues.SetActive(true);
        Debug.Log("Dia Trigg");
	} */

	public GameObject nextRoom;
	public GameObject currRoom;

	private void OnMouseDown () {
		Debug.Log ("hit");
		SoundManager.Instance.gameSounds[0].Play();
		currRoom.SetActive (false);
		nextRoom.SetActive (true);
	}

	private void OnMouseEnter () {
		MousePointer.Instance.SetNormalPointer ();
	}

	private void OnMouseUp () {
		MousePointer.Instance.SetNormalPointer ();
	}
}