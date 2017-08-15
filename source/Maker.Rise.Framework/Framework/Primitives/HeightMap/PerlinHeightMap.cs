using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using Maker.Rise.Framework.Maths;

namespace Maker.Rise.Framework.Primitives.HeightMap
{
    public class PerlinHeightMap : IHeightMap
    {

        public float OffsetX { get; set; } = 80f;
        public float OffsetY { get; set; } = 80f;

        public float HeightStretch { get; set; } = 10f;
        public float XStretch { get; set; } = 1f;
        public float YStretch { get; set; } = 1f;

        public int Octaves { get; set; } = 10;
        public float Persitance { get; set; } = 0.5f;

        public PerlinHeightMap() { }

        public PerlinHeightMap(float offsetX, float offsetY, float heightStretch, float xStretch, float yStretch, int octaves, float persitance)
        {
            OffsetX = offsetX;
            OffsetY = offsetY;
            HeightStretch = heightStretch;
            XStretch = xStretch;
            YStretch = yStretch;
            Octaves = octaves;
            Persitance = persitance;
        }

        public PerlinHeightMap(float heightStretch, float xStretch, float yStretch, int octaves, float persitance)
        {
            HeightStretch = heightStretch;
            XStretch = xStretch;
            YStretch = yStretch;
            Octaves = octaves;
            Persitance = persitance;
        }

        public PerlinHeightMap(int octaves, float persitance)
        {
            Octaves = octaves;
            Persitance = persitance;
        }

        public float GetHeight(float x, float y)
        {
            return (float)Perlin.OctavePerlin(OffsetX + x * XStretch, 0, OffsetY + y * YStretch, Octaves, Persitance) * 10f;
        }

        public Vector3 GetNormal(float x, float y)
        {
            float heightL = GetHeight(x - 0.1f, y);
            float heightR = GetHeight(x + 0.1f, y);
            float heightD = GetHeight(x, y - 0.1f);
            float heightU = GetHeight(x, y + 0.1f);

            Vector3 normal = new Vector3(heightL - heightR, 2f, heightD - heightU);
            normal.Normalize();
            return normal;
        }
    }
}
