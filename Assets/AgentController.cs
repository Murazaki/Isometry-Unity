using UnityEngine;
using System.Collections;

[RequireComponent (typeof (NavMeshAgent))]
public class AgentController : MonoBehaviour {
	private NavMeshAgent agent;
	private GameObject pointer;
	
	public GameObject pointerPrefab;
	public Camera mainCamera;
	
    void Start() {
        agent = GetComponent<NavMeshAgent>();
		pointer = (GameObject)Instantiate(pointerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
    void Update() {
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0)) {
			Debug.Log("Mouse button pushed !");
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000f, LayerMask.NameToLayer("Walls"))) {
				Debug.Log("Raycast Hit !");
				if(hit.collider.CompareTag("Terrain")) {
					if(pointer) {
						pointer.transform.position = hit.point;
					}
					
					agent.SetDestination(hit.point);
				}
			}
        }
    }
}
