using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maker.RiseEngine.Input
{
    public class Keyboard
    {

        public Keyboard()
        {
            keyboardState = OpenTK.Input.Keyboard.GetState();
        }

        private KeyboardState keyboardState;
        private KeyboardState pastKeyboardState;

        public void Update()
        {
            pastKeyboardState = keyboardState;
            keyboardState = OpenTK.Input.Keyboard.GetState();
        }

        public bool IsKeyPress(KeyboardKey key)
        {
            return pastKeyboardState.IsKeyDown((OpenTK.Input.Key)key) && keyboardState.IsKeyUp((OpenTK.Input.Key)key);
        }

        public bool IsKeyUp(KeyboardKey key)
        {
            return keyboardState.IsKeyUp((OpenTK.Input.Key)key);
        }

        public bool IsKeyDown(KeyboardKey key)
        {
            return keyboardState.IsKeyDown((OpenTK.Input.Key)key);
        }
    }
}
