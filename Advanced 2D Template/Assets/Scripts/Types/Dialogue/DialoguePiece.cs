using System;
using UnityEngine;
using UnityEngine.Events;

namespace Types.Dialogue
{
    [Serializable]
    public struct DialoguePiece
    {
        [SerializeField] private string _speaker;
        public readonly string Speaker => _speaker;

        [SerializeField][TextArea] private string _text;
        public readonly string Text => _text;

        [SerializeField] private float _speed;
        public readonly float Speed => _speed;

        [SerializeField] private ScriptableObjects.Text.TMPTextEffect _textEffect;
        public readonly ScriptableObjects.Text.TMPTextEffect TextEffect => _textEffect;

        [SerializeField] private UnityEvent _onDialogue;
        public readonly void InvokeOnDialogue() => _onDialogue?.Invoke();

        [SerializeField] private Collections.Dictionary<string, UnityEvent> _responses;
        public readonly Collections.Dictionary<string, UnityEvent> Responses => _responses;
        public readonly void InvokeResponse(string index) => _responses[index].Invoke();
    }
}
