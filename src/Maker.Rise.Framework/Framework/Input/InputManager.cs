using Maker.Rise.Framework.Graphics;
using Maker.Rise.Framework.Primitives;
using OpenTK.Input;
using System.Collections.Generic;

namespace Maker.Rise.Framework.Input
{
    public class InputManager : EngineComponent, IUpdateable
    {
        public bool Enable { get; set; }
        private KeyboardState oldKeybord;
        private MouseState oldMouse;
        private KeyboardState keyboard;
        private MouseState mouse;
        private GameHost GraphicDevice;

        public InputManager(GameHost graphicDevice)
        {
            GraphicDevice = graphicDevice;
        }

        public override void Load()
        {
            Enable = true;
        }

        public override void Destroy()
        {

        }

        public bool IsKeyBoardKeyDown(KeyboardKey key)
        {
            return keyboard.IsKeyDown((Key)key);
        }

        public bool IsKeyBoardKeyPress(KeyboardKey key)
        {
            return !keyboard.IsKeyDown((Key)key) && oldKeybord.IsKeyDown((Key)key);
        }

        public bool IsMouseLeftKeyDown()
        {
            return mouse.LeftButton == ButtonState.Pressed;
        }

        public bool IsMouseRightKeyDown()
        {
            return mouse.RightButton == ButtonState.Pressed;
        }

        public bool IsMouseMiddleKeyDown()
        {
            return mouse.MiddleButton == ButtonState.Pressed;
        }

        public Point2D GetMousePosition()
        {
            return new Point2D(mouse.X, mouse.Y);
        }

        public Point2D GetMouseDelta()
        {
            return new Point2D(mouse.X - oldMouse.X, mouse.Y - oldMouse.Y);
        }

        public float MouseWheelDelta()
        {
            return mouse.WheelPrecise - oldMouse.WheelPrecise;
        }

        public void Update(float deltaTime)
        {
            if (GraphicDevice.IsGameFocus())
            {
                oldMouse = mouse;
                oldKeybord = keyboard;
                mouse = GraphicDevice.GetMouseDevice().GetState();
                keyboard = GraphicDevice.GetKeyBoardDevice().GetState();
            }
        }
    }
}
