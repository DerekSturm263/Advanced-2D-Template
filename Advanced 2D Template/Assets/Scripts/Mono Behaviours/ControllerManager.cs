using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    [SerializeField] private List<Types.SingletonBehaviourBase> _controllers;
    private List<Types.SingletonBehaviourBase> _controllerInstances;

    private void Awake()
    {
        _controllerInstances = _controllers.Select(item => Instantiate(item)).ToList();

        foreach (Types.SingletonBehaviourBase controllerInstance in _controllerInstances)
        {
            DontDestroyOnLoad(controllerInstance);
        }

        DontDestroyOnLoad(gameObject);
    }
}
