using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maker.Rise.Framework.Input;
using Maker.Rise.Framework.Primitives;
using OpenTK;

namespace Maker.Rise.Framework.Scenes
{
    public class OrbitalCamera : StaticCamera
    {
        public Point3D Focus { get; set; } = new Point3D(0, 0, 0);
        public Vector3 FocusRotation { get; set; } = new Vector3(0, 0, 0);

        public float Distance { get; set; } = 5f;
        public float Angle { get; set; } = 0f;
        public float MinDistance { get; set; } = 1f;
        public float MaxDistance { get; set; } = 10f;

        public OrbitalCamera(float aspectRaciot, float fov = 90) : base(aspectRaciot, fov) { }

        public override void Move(InputManager input)
        {
            Distance = MathHelper.Clamp(Distance - input.MouseWheelDelta() * 0.5f, MinDistance, MaxDistance);

            if (input.IsMouseLeftKeyDown())
            {
                Pitch = (float)MathHelper.Clamp(Pitch + input.GetMouseDelta().Y * 0.01f, -Math.PI / 2, Math.PI / 2);
                Angle -= input.GetMouseDelta().X * 0.01f;
            }

            float HorizDistance = (float)(Distance * Math.Cos(Pitch));
            float VertDistance = (float)(Distance * Math.Sin(Pitch));

            float OffsetX = (float)(HorizDistance * Math.Sin(Angle));
            float OffsetZ = (float)(HorizDistance * Math.Cos(Angle));

            Position.X = Focus.X - OffsetX;
            Position.Y = Focus.Y + VertDistance;
            Position.Z = Focus.Z - OffsetZ;
            Yaw = (float)(Math.PI - Angle);
        }
    }
}
