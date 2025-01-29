using System;
using UnityEngine;
using UnityEngine.Events;

namespace Types.Popup
{
    [Serializable]
    public struct Popup
    {
        [SerializeField] private string _title;
        public readonly string Title => _title;

        [SerializeField][TextArea] private string _description;
        public readonly string Description => _description;

        [SerializeField] private Collections.Dictionary<string, UnityEvent<Callbacks.PopupCallbackContext>> _responses;
        public readonly Collections.Dictionary<string, UnityEvent<Callbacks.PopupCallbackContext>> Responses => _responses;

        [SerializeField] private Miscellaneous.Tuple<string, UnityEvent<string>> _inputResponse;
        public readonly Miscellaneous.Tuple<string, UnityEvent<string>> InputResponse => _inputResponse;
    }
}
