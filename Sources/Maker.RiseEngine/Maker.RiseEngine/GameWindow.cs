using OpenTK.Graphics.OpenGL4;
using Maker.RiseEngine.Graphic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics;
using OpenTK;

namespace Maker.RiseEngine
{
    public class GameWindowDrawEventArgs : EventArgs
    {
        public double DeltaTime { get; private set; }

        public GameWindowDrawEventArgs(double deltaTime)
        {
            DeltaTime = deltaTime;
        }
    }

    public class GameWindowUpdateEventArgs : EventArgs
    {
        public double DeltaTime { get; private set; }

        public GameWindowUpdateEventArgs(double deltaTime)
        {
            DeltaTime = deltaTime;
        }
    }

    public class GameWindow
    {
        private OpenTK.GameWindow OpenTkWindow;


        public GameWindow(int width, int height, string title, bool Fullscreen)
        {
            OpenTkWindow = new OpenTK.GameWindow(width, height, GraphicsMode.Default, title, Fullscreen ? OpenTK.GameWindowFlags.Fullscreen : OpenTK.GameWindowFlags.Default, DisplayDevice.Default, 4,0, GraphicsContextFlags.ForwardCompatible);
            OpenTkWindow.RenderFrame += OnOpenTkWindowRenderFrame;
            OpenTkWindow.UpdateFrame += OnOpenTkWindowUpdateFrame;
            OpenTkWindow.Load += OnOpenTkWindowLoad;
            OpenTkWindow.Resize += OpenTkWindow_Resize;
        }

        private void OpenTkWindow_Resize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, OpenTkWindow.Width, OpenTkWindow.Height);
        }

        #region Draw callback
        public event EventHandler<GameWindowDrawEventArgs> Draw;

        private void OnOpenTkWindowRenderFrame(object sender, OpenTK.FrameEventArgs e)
        {
            Draw?.Invoke(this, new GameWindowDrawEventArgs(e.Time));
        }
        #endregion

        #region Update callback
        public event EventHandler<GameWindowUpdateEventArgs> Update;

        private void OnOpenTkWindowUpdateFrame(object sender, OpenTK.FrameEventArgs e)
        {
            Update?.Invoke(this, new GameWindowUpdateEventArgs(e.Time));
        }
        #endregion

        #region Load callback
        public event EventHandler<EventArgs> Load;
        private void OnOpenTkWindowLoad(object sender, EventArgs e)
        {
            Load?.Invoke(this, new EventArgs());
        }
        #endregion

        public void Show(int updateRate)
        {
            OpenTkWindow.Run(updateRate);
        }

        public void Clear(Color cleanColor)
        {
            GL.ClearColor(new Color4(cleanColor.Red, cleanColor.Green, cleanColor.Blue, cleanColor.Alpha));
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }

        public void SwapBuffer()
        {
            OpenTkWindow.SwapBuffers();
        }


    }
}
