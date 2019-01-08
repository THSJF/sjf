using SlimDX;
using SlimDX.DirectInput;
using System;
using System.Windows.Forms;

namespace Shooting {
    public class KeyboardCapture {
        private Keyboard keyboard;
        public KeyboardState currentKeyboardState;
        public KeyboardState lastKeyboardState;
        public KeyboardCapture(IntPtr handle) {
            DirectInput directInput = new DirectInput();
            CooperativeLevel flags = CooperativeLevel.NoWinKey|CooperativeLevel.Foreground|CooperativeLevel.Exclusive;
            try {
                keyboard=new Keyboard(directInput);
                keyboard.SetCooperativeLevel(handle,flags);
            } catch(DirectInputException ex) {
                int num = (int)MessageBox.Show("DirectInput Error "+ex.Message);
                return;
            }
            keyboard.Acquire();
        }
        public void UpdateInput(ref KeyClass KClass) {
            if(keyboard.Acquire().IsFailure) return;
            Result result = keyboard.Poll();
            if(result.IsFailure) return;
            lastKeyboardState=currentKeyboardState;
            currentKeyboardState=keyboard.GetCurrentState();
            result=Result.Last;
            if(result.IsFailure) return;
            KClass.ArrowLeft=currentKeyboardState.IsPressed(Key.LeftArrow);
            KClass.ArrowRight=currentKeyboardState.IsPressed(Key.RightArrow);
            KClass.ArrowUp=currentKeyboardState.IsPressed(Key.UpArrow);
            KClass.ArrowDown=currentKeyboardState.IsPressed(Key.DownArrow);
            KClass.Key_Shift=currentKeyboardState.IsPressed(Key.LeftShift);
            KClass.Key_Z=currentKeyboardState.IsPressed(Key.Z)|currentKeyboardState.IsPressed(Key.Return);
            KClass.Key_X=currentKeyboardState.IsPressed(Key.X);
            KClass.Key_C=currentKeyboardState.IsPressed(Key.R);
            KClass.Key_Ctrl=currentKeyboardState.IsPressed(Key.LeftControl);
            KClass.Key_ESC=currentKeyboardState.IsPressed(Key.Escape);
            KClass.Key_plus=currentKeyboardState.IsPressed(Key.Equals);
            KClass.Key_minus=currentKeyboardState.IsPressed(Key.Minus);
            KClass.Key_plus|=KClass.Key_Ctrl;
            KClass.Key_minus|=KClass.Key_Shift;
        }
        public void Dispose() {
            if(keyboard!=null) {
                keyboard.Unacquire();
                keyboard.Dispose();
            }
            keyboard=null;
        }
    }
}
