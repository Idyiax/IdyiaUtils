using System;
using System.Collections;
using UnityEngine;

namespace IdyiaUtilities
{
    public static class Animate
    {
        private delegate T InterpolationDelegate<T>(T startValue, T endValue, float t);
        /// <summary>
        /// Animates a value from a given start value to a given end value.
        /// </summary>
        /// <param name="behaviour"> The MonoBehaviour the coroutine is run on. </param>
        /// <param name="duration"> How long the animation will take. </param>
        /// <param name="startValue"> The starting value of the animation. </param>
        /// <param name="endValue"> The ending value of the animation. </param>
        /// <param name="onUpdate"> The delegate that receives the output value. </param>
        /// <param name="easingMode"> The type of easing to be applied to the animation. (optional) </param>
        /// <param name="easingFactor"> The strength of the easing to be applied to the animation. (optional) </param>
        /// <returns> The coroutine of this animation. </returns>
        public static Coroutine AnimateValue<T>(this MonoBehaviour behaviour, float duration, T startValue, T endValue, Action<T> onUpdate, EasingMode easingMode = EasingMode.Linear, float easingFactor = 1) where T : struct
        {
            InterpolationDelegate<T> interpolate;
            switch (typeof(T))
            {
                case Type t when t == typeof(int):
                    interpolate = (startValue, endValue, t) => (T)(object)Mathf.RoundToInt(Mathf.Lerp((int)(object)startValue, (int)(object)endValue, t));
                    break;
                case Type t when t == typeof(float):
                    interpolate = (startValue, endValue, t) => (T)(object)Mathf.Lerp((float)(object)startValue, (float)(object)endValue, t);
                    break;
                case Type t when t == typeof(Vector2):
                    interpolate = (startValue, endValue, t) => (T)(object)Vector2.Lerp((Vector2)(object)startValue, (Vector2)(object)endValue, t);
                    break;
                case Type t when t == typeof(Vector2Int):
                    interpolate = (startValue, endValue, t) => (T)(object)Vector2Int.RoundToInt(Vector2.Lerp((Vector2Int)(object)startValue, (Vector2Int)(object)endValue, t));
                    break;
                case Type t when t == typeof(Vector3):
                    interpolate = (startValue, endValue, t) => (T)(object)Vector3.Lerp((Vector3)(object)startValue, (Vector3)(object)endValue, t);
                    break;
                case Type t when t == typeof(Vector3Int):
                    interpolate = (startValue, endValue, t) => (T)(object)Vector3Int.RoundToInt(Vector3.Lerp((Vector3Int)(object)startValue, (Vector3Int)(object)endValue, t));
                    break;
                case Type t when t == typeof(Color):
                    interpolate = (startValue, endValue, t) => (T)(object)Color.Lerp((Color)(object)startValue, (Color)(object)endValue, t);
                    break;
                case Type t when t == typeof(Quaternion):
                    interpolate = (startValue, endValue, t) => (T)(object)Quaternion.Lerp((Quaternion)(object)startValue, (Quaternion)(object)endValue, t);
                    break;
                default:
                    throw new NotImplementedException($"Type {typeof(T).Name} is not supported.");
            }

            return behaviour.StartCoroutine(Animation<T>(duration, startValue, endValue, onUpdate, easingMode, easingFactor, interpolate));
        }
        /// <summary>
        /// Animates a rotation from a given start value to a given end value.
        /// </summary>
        /// <param name="behaviour"> The MonoBehaviour the coroutine is run on. </param>
        /// <param name="duration"> How long the animation will take. </param>
        /// <param name="startRotation"> The starting value of the animation. </param>
        /// <param name="endRotation"> The ending value of the animation. </param>
        /// <param name="onUpdate"> The delegate that receives the output value. </param>
        /// <param name="easingMode"> The type of easing to be applied to the animation. (optional) </param>
        /// <param name="easingFactor"> The strength of the easing to be applied to the animation. (optional) </param>
        /// <returns> The coroutine of this animation. </returns>
        public static Coroutine AnimateRotation<T>(this MonoBehaviour behaviour, float duration, T startRotation, T endRotation, Action<T> onUpdate, EasingMode easingMode = EasingMode.Linear, float easingFactor = 1) where T : struct
        {
            InterpolationDelegate<T> interpolate;
            switch (typeof(T))
            {
                case Type t when t == typeof(Vector3):
                    interpolate = (startValue, endValue, t) => (T)(object)Vector3.Slerp((Vector3)(object)startValue, (Vector3)(object)endValue, t);
                    break;
                case Type t when t == typeof(Vector3Int):
                    interpolate = (startValue, endValue, t) => (T)(object)Vector3Int.RoundToInt(Vector3.Slerp((Vector3Int)(object)startValue, (Vector3Int)(object)endValue, t));
                    break;
                case Type t when t == typeof(Quaternion):
                    interpolate = (startValue, endValue, t) => (T)(object)Quaternion.Slerp((Quaternion)(object)startValue, (Quaternion)(object)endValue, t);
                    break;
                default:
                    throw new NotImplementedException($"Type {typeof(T).Name} is not supported.");
            }

            return behaviour.StartCoroutine(Animation<T>(duration, startRotation, endRotation, onUpdate, easingMode, easingFactor, interpolate));
        }

        private static IEnumerator Animation<T>(float duration, T startValue, T endValue, Action<T> onUpdate, EasingMode easingMode, float easingFactor, InterpolationDelegate<T> interpolate) where T : struct
        {
            float timeElapsed = 0f;
            float timeMultiplier = 1 / duration;

            while (timeElapsed < duration)
            {
                float easedProgress = Ease(easingMode, easingFactor, timeElapsed * timeMultiplier);
                onUpdate(interpolate(startValue, endValue, easedProgress));

                timeElapsed += Time.deltaTime;
                yield return null;
            }

            onUpdate(endValue);
        }

        // Returns an eased version of a value.
        private static float Ease(EasingMode mode, float easingFactor, float t)
        {
            switch (mode)
            {
                case EasingMode.Linear:
                    return t;
                case EasingMode.EaseIn:
                    return Mathf.Pow(t, easingFactor);
                case EasingMode.EaseOut:
                    return 1 - Mathf.Pow(1 - t, easingFactor);
                case EasingMode.EaseInOut:
                    if (t < 0.5f)
                        return 0.5f * Mathf.Pow(t * 2, easingFactor);
                    else
                        return 1 - 0.5f * Mathf.Pow(1 - t * 2 + 1, easingFactor);
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }
        /// <summary>
        /// The easing mode used for an animation.
        /// </summary>
        public enum EasingMode
        {
            Linear,
            EaseIn,
            EaseOut,
            EaseInOut
        }
    }
}