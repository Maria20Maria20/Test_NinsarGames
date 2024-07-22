using Test_NinsarGames.Scripts.Gameplay;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Test_NinsarGames.Scripts.Inputs
{
    public class InputService : Controls.IPlayerActions
    {
        private Controls _controls;
        private Vector2 _movementDirection;
        private GridController _gridController;
        public Vector2 MovementDirection => _movementDirection;
        InputService(GridController gridController)
        {
            _gridController = gridController;
            _controls = new Controls();
            _controls.Enable();
            _controls.Player.SetCallbacks(this);
        }
        public void OnMovement(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _movementDirection = context.ReadValue<Vector2>();
                _gridController.Move(Vector2Int.RoundToInt(_movementDirection));
            }
        }
        ~InputService()
        {
            _controls.Disable();
        }
    }
}
