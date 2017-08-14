using Maker.Rise.Framework.Graphics;
using Maker.Rise.Framework.Primitives;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Maker.Rise.Framework
{
    public class GameHost
    {
        private GLControl ControlHost = null;
        private GameWindow WindowHost = null;
        private bool IsWindow = true;

        public event Action Load;
        public event Action Draw;
        public event Action<float> Update;
        public event Action Unload;

        private Stopwatch stopWatch;

        public GameHost(GLControl glControl)
        {
            ControlHost = glControl;
            IsWindow = false;
            stopWatch = new Stopwatch();
            ControlHost.Resize += OnResize;
        }

        public GameHost()
        {
            WindowHost = new GameWindow();
            WindowHost.Load += delegate (object sender, EventArgs e) { Load(); };
            WindowHost.UpdateFrame += delegate (object sender, FrameEventArgs e) { Update((float)e.Time); };
            WindowHost.RenderFrame += delegate (object sender, FrameEventArgs e) { Draw(); };
            WindowHost.Unload += delegate (object sender, EventArgs e) { Unload(); };
            WindowHost.Resize += OnResize;
        }

        public GameHost(GameWindow window)
        {
            WindowHost = window;
            WindowHost.VSync = VSyncMode.Off;
            WindowHost.Load += delegate (object sender, EventArgs e) { Load(); };
            WindowHost.UpdateFrame += delegate (object sender, FrameEventArgs e) { Update((float)e.Time); };
            WindowHost.RenderFrame += delegate (object sender, FrameEventArgs e) { Draw(); };
            WindowHost.Unload += delegate (object sender, EventArgs e) { Unload(); };
            WindowHost.Resize += OnResize;
        }

        public void StartRenderLoop(int frameRate)
        {
            if (IsWindow)
            {
                WindowHost.Run(200f);
            }
            else
            {
                Load();
                ControlHost.Paint += GLControlRenderLoop;
            }
        }

        private void GLControlRenderLoop(object sender, PaintEventArgs e)
        {
            ControlHost.MakeCurrent();
            stopWatch.Stop();
            stopWatch.Start();

            Update(stopWatch.Elapsed.Milliseconds / 100);
            Draw();
        }

        public void StopGameLoop()
        {
            if (IsWindow)
            {
                WindowHost.Exit();
            }
            else
            {
                ControlHost.Resize -= OnResize;
                ControlHost.Paint -= GLControlRenderLoop;
                Unload();
            }
        }

        private void OnResize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, (int)GetBufferSize().X, (int)GetBufferSize().Y);
        }

        public Point2D GetBufferSize()
        {
            if (IsWindow)
            {
                return new Point2D(WindowHost.Width, WindowHost.Height);
            }
            else
            {
                return new Point2D(ControlHost.Width, ControlHost.Height);
            }
        }

        public void SetBufferSize(Point2D size)
        {
            GL.Viewport(0, 0, (int)size.X, (int)size.Y);
            if (IsWindow)
            {
                WindowHost.Width = (int)size.X;
                WindowHost.Height = (int)size.Y;
            }
            else
            {

            }
        }

        public void Clear(Color3 color)
        {
            GL.ClearColor(color.Red / 255f, color.Green / 255f, color.Blue / 255f, 0f);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }


        public void SwapBuffers()
        {
            if (IsWindow)
            {
                WindowHost.SwapBuffers();
            }
            else
            {
                ControlHost.SwapBuffers();
            }
        }

        public void SetTitle(string title)
        {
            if (IsWindow)
            {
                WindowHost.Title = title;
            }
        }

        #region inputs

        public MouseDevice GetMouseDevice()
        {
            if (IsWindow)
            {
                return WindowHost.Mouse;
            }
            else
            {
                return new MouseDevice();
            }
        }

        public KeyboardDevice GetKeyBoardDevice()
        {
            if (IsWindow)
            {
                return WindowHost.Keyboard;
            }
            else
            {
                return null;
            }
        }

        public bool IsGameFocus()
        {
            if (IsWindow)
            {
                return WindowHost.Focused;
            }
            else
            {
                return ControlHost.Focused;
            }
        }
        #endregion
    }
}
