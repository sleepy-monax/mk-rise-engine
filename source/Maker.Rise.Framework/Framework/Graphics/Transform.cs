using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maker.Rise.Framework.Graphics
{
    public class Transform
    {
        public Vector3 Position;
        public float Scale;
        public Vector3 Rotation;

        public Transform(float x, float y, float z)
        {
            Position = new Vector3(x, y, z);
            Scale = 1f;
            Rotation = Vector3.Zero;
        }

        public Transform(Vector3 position, Vector3 rotation, float scale = 1f)
        {
            Position = position; Rotation = rotation; Scale = scale;
        }

        public Matrix4 GetTransformationMatrix()
        {

            return Matrix4.Identity * Matrix4.CreateScale(Scale) * Matrix4.CreateRotationX(Rotation.X) * Matrix4.CreateRotationY(Rotation.Y) * Matrix4.CreateRotationZ(Rotation.Z) * Matrix4.CreateTranslation(Position);
        }
    }
}
