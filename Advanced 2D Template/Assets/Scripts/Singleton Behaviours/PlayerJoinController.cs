using System.Collections.Generic;
using System.Linq;
using Types.Multiplayer;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace SingletonBehaviours
{
    public class PlayerJoinController : Types.SingletonBehaviour<PlayerJoinController>
    {
        private readonly List<LocalPlayer<InputSystem_Actions>> _localPlayers = new();

        [SerializeField] private InputActionReference _join;
        [SerializeField] private InputActionReference _leave;

        [SerializeField] private UnityEvent<LocalPlayer<InputSystem_Actions>> _onJoin;
        [SerializeField] private UnityEvent<LocalPlayer<InputSystem_Actions>> _onLeave;

        [SerializeField] private int _playerLimit;
        public int PlayerLimit => _playerLimit;
        public void SetPlayerLimit(int playerLimit) => Instance._playerLimit = playerLimit;

        public IEnumerable<LocalPlayer<InputSystem_Actions>> GetAllLocalPlayers(bool limitCount)
        {
            for (int i = 0; i < _localPlayers.Count; ++i)
            {
                if (limitCount && i == _playerLimit)
                    break;

                yield return _localPlayers[i];
            }
        }

        public int GetPlayerCount(bool limitCount) => GetAllLocalPlayers(limitCount).Count();

        public override void Initialize()
        {
            _join.action.performed += TryPlayerJoin;
            _leave.action.performed += TryPlayerLeave;
        }

        private void TryPlayerJoin(InputAction.CallbackContext ctx)
        {
            LocalPlayer<InputSystem_Actions> player = new();
            _onJoin.Invoke(player);
        }

        private void TryPlayerLeave(InputAction.CallbackContext ctx)
        {

        }
    }
}
