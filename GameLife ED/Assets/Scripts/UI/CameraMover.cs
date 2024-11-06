using Unity.VisualScripting;
using UnityEngine;

class CamMover: MonoBehaviour {

    void Start () {

        showStartPoint();
        hideSettingsPoint();
        hideGamePoint();
    }

    void  Update () {
        
        if (distCovered_ < journeyLength_) {

            distCovered_ += Time.deltaTime * speed_;

            float fractionOfJourney = distCovered_ / journeyLength_;

            float q = 0.5f * Mathf.Sin(fractionOfJourney * Mathf.PI - Mathf.PI / 2f) + 0.5f;

            transform.position = Vector3.Lerp(startMarker_.position, endMarker_.position, q);
            transform.rotation = Quaternion.Lerp(startMarker_.rotation, endMarker_.rotation, q);
        }
    }

    void moveCamera (Transform start, Transform end, float movementTime) {

        startMarker_ = start;
          endMarker_ = end;

        distCovered_ = 0;
        journeyLength_ = Vector3.Distance(startMarker_.position, endMarker_.position);

        speed_ = journeyLength_ / movementTime;
    }


    //---Shit-Code---

    //---Moving---

    public void moveFromStartToSettings (float movementTime) {

        Invoke("hideStartPoint", 0);

        transform.position = startPoint.transform.position;
        transform.rotation = startPoint.transform.rotation;

        moveCamera(startPoint.transform, settingsPoint.transform, movementTime);

        Invoke("showSettingsPoint", movementTime);
    }

    public void moveFromSettingsToStart (float movementTime) {

        Invoke("hideSettingsPoint", 0);

        transform.position = settingsPoint.transform.position;
        transform.rotation = settingsPoint.transform.rotation;

        moveCamera(settingsPoint.transform, startPoint.transform, movementTime);

        Invoke("showStartPoint", movementTime);
    }

    public void moveFromStartToGame (float movementTime) {

        Invoke("hideStartPoint", 0);

        transform.position = startPoint.transform.position;
        transform.rotation = startPoint.transform.rotation;

        moveCamera(startPoint.transform, gamePoint.transform, movementTime);

        Invoke("showGamePoint", movementTime);
    }

    public void moveFromGameToStart (float movementTime) {

        Invoke("hideGamePoint", 0);

        transform.position = gamePoint.transform.position;
        transform.rotation = gamePoint.transform.rotation;

        moveCamera(gamePoint.transform, startPoint.transform, movementTime);

        Invoke("showStartPoint", movementTime);
    }

    //---Point-Viewing---

    public void hideStartPoint () {

        startPoint.SetActive(false);
    }

    public void showStartPoint () {

        startPoint.SetActive(true);
    }

    public void hideSettingsPoint () {

        settingsPoint.SetActive(false);
    }

    public void showSettingsPoint () {

        settingsPoint.SetActive(true);
    }

    public void hideGamePoint () {

        gamePoint.SetActive(false);
    }

    public void showGamePoint () {

        gamePoint.SetActive(true);
    }

    //----------------

    //---Class-Data---

    [SerializeField] private GameObject    startPoint;
    [SerializeField] private GameObject     gamePoint;
    [SerializeField] private GameObject settingsPoint;

    private Transform startMarker_;
    private Transform endMarker_;

    private float speed_ = 1;

    private float distCovered_ = 0;
    private float journeyLength_ = 0;
}
