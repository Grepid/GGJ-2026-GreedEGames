using NUnit.Framework;
using System.Data;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;


public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError($"Tried to access {typeof(T)} while Instance was null.");
                return null;
            }
            return _instance;
        }
        private set
        {
            _instance = value;
        }
    }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            Debug.Log($"Assigned instance of type {typeof(T)}");
            _instance = this as T;
        }
        else
        {
            Debug.LogWarning($"Tried to instantiate a {typeof(T)} while there was a pre-existing Instance");
            Destroy(gameObject);
        }
    }
}

