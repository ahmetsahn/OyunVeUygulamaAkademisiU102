using ScriptableObjectArchitecture;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool aim;
		public bool shoot;
		public bool swapWeapon;
        public bool enterShip;
        public bool reloadBullet;
        public BoolReference openMarketPanel;
        public BoolReference closeMarketPanel;

        [Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

        public void OnAim(InputValue value)
        {
            AimInput(value.isPressed);
        }

        public void OnShoot(InputValue value)
        {
            ShootInput(value.isPressed);
        }

        public void OnSwapWeapon(InputValue value)
        {
            SwapWeaponInput(value.isPressed);
        }

        public void OnEnterShip(InputValue value)
        {
            EnterShipInput(value.isPressed);
        }

        public void OnReloadBullet(InputValue value)
        {
            ReloadBulletInput(value.isPressed);
        }

        public void OnOpenMarketPanel(InputValue value)
        {
            
            cursorInputForLook = false;
            OpenMarketPanelInput(value.isPressed);
        }

        public void OnCloseMarketPanel(InputValue value)
        {
            
            cursorInputForLook = true;
            CloseMarketPanelInput(value.isPressed);
        }

#endif


        public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

        public void AimInput(bool newAimState)
        {
			aim = newAimState;
        }

		public void ShootInput(bool newShootState)
		{
            shoot = newShootState;
        }

        public void SwapWeaponInput(bool newSwapWeaponState)
		{
            swapWeapon = newSwapWeaponState;
        }

        public void EnterShipInput(bool newEnterShipState)
		{
            enterShip = newEnterShipState;
        }

        public void ReloadBulletInput(bool newReloadBulletState)
		{
            reloadBullet = newReloadBulletState;
        }

        public void OpenMarketPanelInput(bool newOpenMarketPanelState)
        {
            openMarketPanel.Value = newOpenMarketPanelState;
        }

        public void CloseMarketPanelInput(bool newCloseMarketPanelState)
        {
            closeMarketPanel.Value = newCloseMarketPanelState;
        }

        private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}

        
	}
	
}