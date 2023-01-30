using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RayShooter : MonoBehaviour
{
    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 point = new Vector3(camera.pixelWidth / 2, camera.pixelHeight / 2, 0);
            Ray ray = camera.ScreenPointToRay(point);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    target.ReactToHit();
                    Messenger.Broadcast(GameEvent.ENEMY_HIT);
                }
                else
                {
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }
    }

    void OnGUI()
    {
        int size = 25;
        float posX = camera.pixelWidth / 2 - size / 4;
        float posY = camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "+");
    }

    private IEnumerator SphereIndicator(Vector3 pos)
    {
        float sphereScale = 0.2f;
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.AddComponent(typeof(MeshRenderer));
        sphere.GetComponent<MeshRenderer>().material.color = Color.red;
        sphere.transform.localScale = new Vector3(sphereScale, sphereScale, sphereScale);
        sphere.transform.position = pos; 
       
        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }
}
