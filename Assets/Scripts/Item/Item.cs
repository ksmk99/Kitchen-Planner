using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour
{
    public bool IsGrounded => isGrounded;

    [SerializeField] private bool isInstalled;

    private ColorChanger colorChanger;
    private OffsetPoints offsetPoints;
    private Environment environment;
    private SnapPoints snapPoints;
    private Camera camera;

    private MeshRenderer meshRenderer;
    private Vector3 snapOffset;

    private bool isGoodPlace;
    private bool isGrounded;

    private void Awake()
    {
        SetComponents();
    }

    private void Update()
    {
        if (isInstalled) return;
        UpdatePosition();
        CheckSnap();
        PlaceItem();
    }

    private void PlaceItem()
    {
        if (Input.GetMouseButtonUp(0) && isGoodPlace)
        {
            isInstalled = true;
            colorChanger.TransitionTo(new Installed());
            gameObject.layer = 0;
            isGrounded = environment.IsGrounded(transform, offsetPoints);
        }
        else if(Input.GetMouseButtonUp(0) && !isGoodPlace)
            Destroy(gameObject);
    }

    private void UpdatePosition()
    {
        var ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var environment = hit.transform.GetComponent<Environment>();
            if (environment != null)
            {
                this.environment = environment;
                transform.rotation = hit.transform.rotation;
                transform.position = hit.point;

                var translateValue = environment is Floor ?
                    -Vector3.up * offsetPoints.FloorBotOffset :
                    -Vector3.forward * offsetPoints.WallBackOffset;
                transform.Translate(translateValue);
            }
        }
    }

    private void CheckSnap()
    {
        snapOffset = snapPoints.GetSnapOffset();
        var changeVector = environment == null ? Vector3.one : environment.CnahgeVector;
        transform.position += new Vector3(
            changeVector.x * snapOffset.x,
            changeVector.y * snapOffset.y,
            changeVector.z * snapOffset.z);

        if (environment != null)
        {
            environment.CheckLimits(transform, offsetPoints);
        }
    }

    private void SetComponents()
    {
        camera = Camera.main;
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        offsetPoints = GetComponentInChildren<OffsetPoints>();
        snapPoints = GetComponentInChildren<SnapPoints>();
        colorChanger = GetComponentInChildren<ColorChanger>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (isInstalled) return;
        if (other.GetComponent<Item>() != null)
        {
            colorChanger.TransitionTo(new BadPosition());
            isGoodPlace = false;
        }
        else if (other.GetComponent<Environment>() != null)
        {
            colorChanger.TransitionTo(new GoodPosition());
            isGoodPlace = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (isInstalled) return;
        if (other.GetComponent<Item>() != null)
        {
            colorChanger.TransitionTo(new GoodPosition());
            isGoodPlace = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isInstalled) return;
        if (other.GetComponent<Item>() != null)
        {
            colorChanger.TransitionTo(new BadPosition());
            isGoodPlace = false;
        }
    }

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            isInstalled = false;
            colorChanger.TransitionTo(new GoodPosition());
            gameObject.layer = 2;
        }
    }
}
