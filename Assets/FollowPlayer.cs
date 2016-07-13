using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	public GameObject player;
	private Vector3 playerViewportPos;
	
	public Camera mainCamera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		playerViewportPos = mainCamera.WorldToViewportPoint(player.transform.position);
		
		Debug.Log("playerViewportPos : " + playerViewportPos);
		
		
		
		transform.localPosition = Vector3.Scale((playerViewportPos - 0.5f * Vector3.one), new Vector3(30f, 20f, 0f))
							+ Vector3.Project(transform.localPosition, Vector3.forward);
							
		Debug.Log("See Through Camera Pos : " + transform.localPosition);
	}
}
