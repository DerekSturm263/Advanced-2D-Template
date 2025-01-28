using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Types.Dialogue
{
    [Serializable]
    public struct Dialogue
    {
        [SerializeField] private List<DialoguePiece> _dialogues;
        public readonly List<DialoguePiece> Dialogues => _dialogues;

        [SerializeField] private float _eventDelay;
        public readonly float EventDelay => _eventDelay;

        [SerializeField] private UnityEvent _onDialogueEnd;
        public readonly void InvokeOnDialogueEnd() => _onDialogueEnd?.Invoke();
    }
}
