using System;
using UnityEngine;


public struct TimeSince : IEquatable<TimeSince>, IEquatable<float>
{
	private TimeSince(float time)
	{
		_time = Time.time - time;
	}

	public float Relative => this;

	public override string ToString()
	{
		return Relative.ToString();
	}

	private float _time;

	public static implicit operator float(TimeSince ts)
	{
		return Time.time - ts._time;
	}

	public static implicit operator TimeSince(float ts)
	{
		return new TimeSince(ts);
	}

	public override bool Equals(object obj)
	{
		if (obj is float value)
		{
			return value.Equals(Time.time - _time);
		}

		return obj is TimeSince other && Equals(other);
	}

	public bool Equals(TimeSince other)
	{
		return _time.Equals(other._time);
	}

	public bool Equals(float other)
	{
		return (Time.time - _time).Equals(other);
	}

	public override int GetHashCode()
	{
		return _time.GetHashCode();
	}
}

public struct RealTimeSince : IEquatable<RealTimeSince>, IEquatable<float>
{
	private RealTimeSince(float time)
	{
		_time = Time.unscaledTime - time;
	}

	public float Relative => this;

	public override string ToString()
	{
		return Relative.ToString();
	}

	private float _time;

	public static implicit operator float(RealTimeSince ts)
	{
		return Time.unscaledTime - ts._time;
	}

	public static implicit operator RealTimeSince(float ts)
	{
		return new RealTimeSince(ts);
	}

	public override bool Equals(object obj)
	{
		if (obj is float value)
		{
			return value.Equals(Time.unscaledTime - _time);
		}

		return obj is TimeSince other && Equals(other);
	}

	public bool Equals(RealTimeSince other)
	{
		return _time.Equals(other._time);
	}

	public bool Equals(float other)
	{
		return (Time.unscaledTime - _time).Equals(other);
	}

	public override int GetHashCode()
	{
		return _time.GetHashCode();
	}
}

public static class ColorExtensions
{
	public static Color WithRed(this Color input, float value)
	{
		return new Color(value, input.g, input.b, input.a);
	}

	public static Color WithGreen(this Color input, float value)
	{
		return new Color(input.r, value, input.b, input.a);
	}

	public static Color WithBlue(this Color input, float value)
	{
		return new Color(input.r, input.g, value, input.a);
	}

	public static Color WithAlpha(this Color input, float value)
	{
		return new Color(input.r, input.g, input.b, value);
	}

	public static Color LerpTo(this Color input, Color b, float t)
	{
		return Color.Lerp(input, b, t);
	}

}

public static class Vector3Extensions
{
	// With

	public static Vector3 WithX(this Vector3 vector, float value)
	{
		return new Vector3(value, vector.y, vector.z);
	}

	public static Vector3 WithY(this Vector3 vector, float value)
	{
		return new Vector3(vector.x, value, vector.z);
	}

	public static Vector3 WithZ(this Vector3 vector, float value)
	{
		return new Vector3(vector.x, vector.y, value);
	}

	// Flip

	public static Vector3 FlipX(this Vector3 v)
	{
		return new Vector3(-v.x, v.y, v.z);
	}

	public static Vector3 FlipY(this Vector3 v)
	{
		return new Vector3(v.x, -v.y, v.z);
	}

	public static Vector3 FlipZ(this Vector3 v)
	{
		return new Vector3(v.x, v.y, -v.z);
	}

	// Lerp

	public static Vector3 LerpTo(this Vector3 input, Vector3 b, float t)
	{
		return Vector3.Lerp(input, b, t);
	}

	public static Vector3 SlerpTo(this Vector3 input, Vector3 b, float t)
	{
		return Vector3.Slerp(input, b, t);
	}

	public static Vector3 ProjectileCalculateLead(Vector3 startPosition, Vector3 targetPosition, Vector3 targetVelocity, float velocity)
	{
		float distance = Vector3.Distance(startPosition, targetPosition);
		float travelTime = distance / (velocity);
		return (targetPosition + targetVelocity * travelTime);
	}

	public static float Dot(this Vector3 input, Vector3 b)
	{
		return Vector3.Dot(input, b);
	}
}

public static class QuaternionExtensions
{
	// Vector Math

	public static Vector3 Up(this Quaternion quaternion)
	{
		return quaternion * Vector3.up;
	}

	public static Vector3 Down(this Quaternion quaternion)
	{
		return quaternion * Vector3.down;
	}

	public static Vector3 Right(this Quaternion quaternion)
	{
		return quaternion * Vector3.right;
	}

	public static Vector3 Left(this Quaternion quaternion)
	{
		return quaternion * Vector3.left;
	}

	public static Vector3 Forward(this Quaternion quaternion)
	{
		return quaternion * Vector3.forward;
	}

	public static Vector3 Backward(this Quaternion quaternion)
	{
		return quaternion * Vector3.back;
	}

	// Axis

	public static float Pitch(this Quaternion quaternion)
	{
		return quaternion.eulerAngles.x;
	}

	public static float Yaw(this Quaternion quaternion)
	{
		return quaternion.eulerAngles.y;
	}

	public static float Roll(this Quaternion quaternion)
	{
		return quaternion.eulerAngles.z;
	}
}

public static class RandomExtensions
{
	public static float Range(Vector2 range)
	{
		return UnityEngine.Random.Range(range.x, range.y);
	}
}


