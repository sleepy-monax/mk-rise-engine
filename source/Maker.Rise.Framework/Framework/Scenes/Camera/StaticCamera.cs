using Maker.Rise.Framework.Input;
using Maker.Rise.Framework.Primitives;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maker.Rise.Framework.Scenes.Camera
{
    public class StaticCamera
    {

        //http://img.over-blog-kiwi.com/1/56/22/18/20151217/ob_9154fe_cam-yaw-pitch-roll.png
        public Point3D Position { get; set; } = new Point3D();
        public float Pitch { get; set; } = 0f;
        public float Yaw { get; set; } = 0f;
        public float Roll { get; set; } = 0f;


        public float Fov { get; set; }
        public float AspectRacio { get; set; }

        public StaticCamera(float aspectRaciot, float fov = 90)
        {
            Fov = fov;
            AspectRacio = aspectRaciot;
        }

        public Matrix4 GetProjectionMatrix()
        {
            return Matrix4.CreatePerspectiveFieldOfView(1f, AspectRacio, 0.1f, 1000f);
        }

        public Matrix4 GetViewMatrix()
        {
            Vector3 AntiCamPosition = new Vector3(-Position.X, -Position.Y, -Position.Z);
            return Matrix4.Identity * Matrix4.CreateTranslation(AntiCamPosition) * Matrix4.CreateRotationY(Yaw) * Matrix4.CreateRotationX(Pitch) * Matrix4.CreateRotationZ(Roll);
        }

        public virtual void Move(InputManager input)
        { }
    }
}
