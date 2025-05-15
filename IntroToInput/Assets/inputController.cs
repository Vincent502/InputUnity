using UnityEngine;
using UnityEngine.InputSystem;
using PrimeTween;
using static UnityEngine.InputSystem.InputAction;


public class inputController : MonoBehaviour
{
    //public RawImage _image;
    private Transform _imageTransform;
    [SerializeField] GameObject _container;
    [SerializeField] LayerMask _mask;
    Camera _camera;
    private float mousePositionX;
    private float mousePositionZ;
    private Tween _currentMove;
    [SerializeField] private GameObject prefab;
    private Mesh _bob;
    [SerializeField] private GameObject _hitPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _camera = Camera.main;
        //_image = GetComponent<RawImage>();
        //_imageTransform = _image.transform;

    }


    // Update is called once per frame
    void Update()
    {
        //si tu maintient le clic l'image suivra le curseur
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Ray ray = _camera.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, _mask))
        {
            if (Mouse.current.leftButton.isPressed)
            {
                //deplace au clic
                _currentMove.Stop();
                _currentMove = Tween.PositionAtSpeed(transform, hitInfo.point, _mask);
            }

            //fait tourner la vue vers le curseur
            Vector3 direction = hitInfo.point - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;

        }
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            GameObject instance = Instantiate(prefab, hitInfo.point, Quaternion.identity);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 5)
        {
            GameObject instance = Instantiate(_hitPrefab, collision.transform.position, Quaternion.identity);
            instance.transform.position = new Vector3();
        }

    }
 }


