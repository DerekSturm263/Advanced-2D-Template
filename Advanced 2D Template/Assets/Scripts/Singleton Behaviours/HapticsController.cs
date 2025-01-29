using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SingletonBehaviours
{
    public class HapticsController : Types.SingletonBehaviour<HapticsController>
    {
        public void Rumble(Types.Multiplayer.LocalPlayer<InputSystem_Actions> player, float frequency, float time) => StartCoroutine(RumbleCoroutine(player, frequency, time));

        private IEnumerator RumbleCoroutine(Types.Multiplayer.LocalPlayer<InputSystem_Actions> player, float frequency, float time)
        {
            if (player.Device is Gamepad gamepad)
            {
                gamepad.SetMotorSpeeds(frequency, frequency);

                gamepad.ResumeHaptics();
                yield return new WaitForSeconds(time);
                gamepad.PauseHaptics();
            }
        }
    }
}
