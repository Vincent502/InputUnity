using UnityEngine;
using PrimeTween;
using UnityEditor.PackageManager;
using UnityEditor;
using Unity.VisualScripting;

public class Colorchange : MonoBehaviour
{
    [Header ("setting")]
    [SerializeField] private float _count = 20f;
    private LayerMask _mask;
    private Mesh _bob;
    private GameObject _hitPrefab; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _count -= Time.deltaTime;
        if (_count <= 0)
        {
            Destroy(gameObject);
        }
    }
    
}
