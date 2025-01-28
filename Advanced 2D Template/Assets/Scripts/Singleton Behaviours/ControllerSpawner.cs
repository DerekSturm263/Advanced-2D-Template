using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ControllerSpawner : Types.SingletonBehaviour<ControllerSpawner>
{
    [SerializeField] private List<Types.SingletonBehaviourBase> _controllers;
    private List<Types.SingletonBehaviourBase> _controllerInstances;

    private void Awake()
    {
        _controllerInstances = _controllerInstances.Select(item => Instantiate(item)).ToList();

        foreach (Types.SingletonBehaviourBase controllerInstance in _controllerInstances)
        {
            DontDestroyOnLoad(controllerInstance);
            controllerInstance.Initialize();
        }

        Application.quitting += ShutdownAll;
        DontDestroyOnLoad(gameObject);
    }

    private void ShutdownAll()
    {
        foreach (Types.SingletonBehaviourBase controllerInstance in _controllerInstances)
        {
            controllerInstance.Shutdown();
        }
    }
}
