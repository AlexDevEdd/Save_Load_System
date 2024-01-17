using System;

namespace _Project.Scripts.Tools
{
	public static class MathExtensionMethods
	{
		public const float PRECISION  = 0.000001f;

		public static bool EqualTo(this float a, float b, float precision = PRECISION)
		{
			return (a - b).Abs() < precision;
		}

		public static float Abs(this float a)
		{
			return a < 0 ? -a : a;
		}

		public static int Abs(this int a)
		{
			return a < 0 ? -a : a;
		}

		public static float Clamp(this float value, float min = 0, float max = 1)
		{
			return value > max ? max :
			       value < min ? min : value;
		}
		
		public static double Clamp(this double value, double min = 0, double max = 1)
		{
			return value > max ? max :
				value < min ? min : value;
		}

		public static float ClampRange(this float value, float range = 1) => value.Clamp(-range, range);

		public static float IncInRange(this float value, float delta, float range) =>
			(value + delta).Clamp(-range, range);

		public static float Positiveness(this float a)
		{
			return a < 0 ? -1 : 1;
		}

		public static bool SamePositiveness(this int a, int b) => (a < 0 && b < 0) || (a >= 0 && b >= 0);
		
		public static bool SamePositiveness(this float a, float b) => (a < 0 && b < 0) || (a >= 0 && b >= 0);
		
		public static int FloorToInt(this float f)
		{
			return (int) Math.Floor(f);
		}
		
		public static int CeilToInt(this float f)
		{
			return (int) Math.Ceiling(f);
		}
	}
}