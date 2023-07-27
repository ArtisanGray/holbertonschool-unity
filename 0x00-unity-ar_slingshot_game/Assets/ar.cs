using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using Unity.AI.Navigation;
using UnityEngine.AI;

public class ar : MonoBehaviour
{
    public Camera arCam;
    private Vector2 _touchPos;
    public Button qButton;
    public Button rButton;
    public Button scoreBoard;
    public Slider ammoSlide;

    private ARPlaneManager _arMan;
    private ARRaycastManager _arManRay;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    public Pose planePose;
    public GameObject selectedPlane;
    public NavMeshAgent selectedTarget;
    private List<NavMeshAgent> targets = new List<NavMeshAgent>();

    public Text touch;
    public Text rCastInfo;
    public Button tNotification;

    private ColorBlock _notifColors;

    public int numEnemies = 5;
    public int score = 0;

    private void Awake()
    {
        _arMan = GetComponent<ARPlaneManager>();
        _arManRay = GetComponent<ARRaycastManager>();
    }
    void Update()
    {
        if (_arMan.trackables.count > 0 && selectedPlane == null)//-----> the "searching..." graphic. changes color when a trackable has been found.
        {
            _notifColors = tNotification.GetComponent<Button>().colors;
            _notifColors.normalColor = Color.green;
            tNotification.GetComponent<Button>().colors = _notifColors;
            tNotification.GetComponentInChildren<Text>().text = "Select a Plane";
        }
        if (Input.touchCount > 0)
        {
            _touchPos = Input.GetTouch(0).position;
            touch.GetComponent<Text>().text = _touchPos.ToString();

            if (_arManRay.Raycast(_touchPos, hits, TrackableType.PlaneWithinPolygon))//-----> casts a ray from screen touch's position to plane facing main camera.
            {
                planePose = hits[0].pose;
                var planeId = hits[0].trackableId;
                rCastInfo.GetComponent<Text>().text = planePose.ToString();

                foreach (var plane in _arMan.trackables)//-----> deletes all other trackables on-screen to the one selected by the player.
                {

                    if (plane.trackableId != planeId)
                        Destroy(plane.gameObject);
                    else
                    {
                        selectedPlane = plane.gameObject;//-----> saves gameobject, bakes navmesh for enemies, and adds a sample target.
                        BakeMesh(selectedPlane);
                        _notifColors.normalColor = Color.cyan;//-----> changes the color and orientation of the "searching..." graphic to be a 'Start' button instead.
                        _notifColors.pressedColor = new Color(0.0f, 0.3f, 0.3f);
                        tNotification.transform.localPosition = new Vector3(0f, 0f, 0f);
                        tNotification.transform.localScale = new Vector3(5f, 5f, 5f);
                        tNotification.GetComponent<RectTransform>().sizeDelta = new Vector2(150f, 40f);
                        tNotification.GetComponent<Button>().colors = _notifColors;
                        tNotification.GetComponentInChildren<Text>().text = "Start";
                        tNotification.onClick.AddListener(startGame);
                    }
                }
                _arMan.enabled = false;
                _arManRay.enabled = false;//-----> disables the Plane Manager and Raycast Manager so there are no more trackables added.
            }
        }
    }
    public void BakeMesh(GameObject sPlane)
    {
        if (sPlane.TryGetComponent<NavMeshSurface>(out NavMeshSurface sampleSurf))
        {
            selectedPlane.GetComponent<NavMeshSurface>().BuildNavMesh();
        }
    }
    public void startGame()
    {
        scoreBoard.gameObject.SetActive(true);
        qButton.gameObject.SetActive(true);
        rButton.gameObject.SetActive(true);
        ammoSlide.gameObject.SetActive(true);
        tNotification.gameObject.SetActive(false);
        NavMeshTriangulation whereiGo = NavMesh.CalculateTriangulation();
        NavMeshHit BattleBusHit;
        for (int i = 0; i < numEnemies; i++)
        {
            int vertIndex = Random.Range(0, whereiGo.vertices.Length);
            if (NavMesh.SamplePosition(whereiGo.vertices[vertIndex], out BattleBusHit, 2f, NavMesh.AllAreas))
            {
                targets.Add(Instantiate(selectedTarget, BattleBusHit.position, planePose.rotation));
            }
            vertIndex = 0;
        }

    }

}
