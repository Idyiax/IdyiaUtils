using System;
using System.Collections;
using UnityEngine;

namespace IdyiaUtilities
{
    public static class Tween
    {
        private delegate T InterpolationDelegate<T>(T startValue, T endValue, float t);

        #region Tween Value Overloads
        /// <summary>
        /// Tweens a value from a given start value to a given end value.
        /// </summary>
        /// <param name="behaviour"> The MonoBehaviour the coroutine is run on. </param>
        /// <param name="duration"> How many seconds the tween will take. </param>
        /// <param name="startValue"> The starting value of the tween. </param>
        /// <param name="endValue"> The ending value of the tween. </param>
        /// <param name="onUpdate"> The delegate that's given the current value each time it's updated. </param>
        /// <returns> The coroutine of this tween. </returns>
        public static Coroutine TweenValue<T>(this MonoBehaviour behaviour, float duration, T startValue, T endValue, Action<T> onUpdate) where T : struct =>
            TweenValue<T>(behaviour, duration, startValue, endValue, onUpdate, EasingMode.Linear, 1, null);
        /// <summary>
        /// Tweens a value from a given start value to a given end value.
        /// </summary>
        /// <param name="behaviour"> The MonoBehaviour the coroutine is run on. </param>
        /// <param name="duration"> How many seconds the tween will take. </param>
        /// <param name="startValue"> The starting value of the tween. </param>
        /// <param name="endValue"> The ending value of the tween. </param>
        /// <param name="onUpdate"> The delegate that's given the current value each time it's updated. </param>
        /// <param name="onComplete"> The delegate that's run after the tween is complete. </param>
        /// <returns> The coroutine of this tween. </returns>
        public static Coroutine TweenValue<T>(this MonoBehaviour behaviour, float duration, T startValue, T endValue, Action<T> onUpdate, Action onComplete) where T : struct =>
            TweenValue<T>(behaviour, duration, startValue, endValue, onUpdate, EasingMode.Linear, 1, onComplete);
        /// <summary>
        /// Tweens a value from a given start value to a given end value.
        /// </summary>
        /// <param name="behaviour"> The MonoBehaviour the coroutine is run on. </param>
        /// <param name="duration"> How many seconds the tween will take. </param>
        /// <param name="startValue"> The starting value of the tween. </param>
        /// <param name="endValue"> The ending value of the tween. </param>
        /// <param name="onUpdate"> The delegate that's given the current value each time it's updated. </param>
        /// <param name="easingMode"> The type of easing to be applied to the tween. </param>
        /// <returns> The coroutine of this tween. </returns>
        public static Coroutine TweenValue<T>(this MonoBehaviour behaviour, float duration, T startValue, T endValue, Action<T> onUpdate, EasingMode easingMode) where T : struct =>
            TweenValue<T>(behaviour, duration, startValue, endValue, onUpdate, easingMode, 1, null);
        /// <summary>
        /// Tweens a value from a given start value to a given end value.
        /// </summary>
        /// <param name="behaviour"> The MonoBehaviour the coroutine is run on. </param>
        /// <param name="duration"> How many seconds the tween will take. </param>
        /// <param name="startValue"> The starting value of the tween. </param>
        /// <param name="endValue"> The ending value of the tween. </param>
        /// <param name="onUpdate"> The delegate that's given the current value each time it's updated. </param>
        /// <param name="easingMode"> The type of easing to be applied to the tween. </param>
        /// <param name="onComplete"> The delegate that's run after the tween is complete. </param>
        /// <returns> The coroutine of this tween. </returns>
        public static Coroutine TweenValue<T>(this MonoBehaviour behaviour, float duration, T startValue, T endValue, Action<T> onUpdate, EasingMode easingMode, Action onComplete) where T : struct =>
            TweenValue<T>(behaviour, duration, startValue, endValue, onUpdate, easingMode, 1, onComplete);
        /// <summary>
        /// Tweens a value from a given start value to a given end value.
        /// </summary>
        /// <param name="behaviour"> The MonoBehaviour the coroutine is run on. </param>
        /// <param name="duration"> How many seconds the tween will take. </param>
        /// <param name="startValue"> The starting value of the tween. </param>
        /// <param name="endValue"> The ending value of the tween. </param>
        /// <param name="onUpdate"> The delegate that's given the current value each time it's updated. </param>
        /// <param name="easingMode"> The type of easing to be applied to the tween. </param>
        /// <returns> The coroutine of this tween. </returns>
        public static Coroutine TweenValue<T>(this MonoBehaviour behaviour, float duration, T startValue, T endValue, Action<T> onUpdate, EasingMode easingMode, float easingFactor) where T : struct =>
            TweenValue<T>(behaviour, duration, startValue, endValue, onUpdate, easingMode, easingFactor, null);
        /// <summary>
        /// Tweens a value from a given start value to a given end value.
        /// </summary>
        /// <param name="behaviour"> The MonoBehaviour the coroutine is run on. </param>
        /// <param name="duration"> How many seconds the tween will take. </param>
        /// <param name="startValue"> The starting value of the tween. </param>
        /// <param name="endValue"> The ending value of the tween. </param>
        /// <param name="onUpdate"> The delegate that's given the current value each time it's updated. </param>
        /// <param name="easingMode"> The type of easing to be applied to the tween. </param>
        /// <param name="easingFactor"> The strength of the easing to be applied to the tween. </param>
        /// <param name="onComplete"> The delegate that's run after the tween is complete. </param>
        /// <returns> The coroutine of this tween. </returns>
        public static Coroutine TweenValue<T>(this MonoBehaviour behaviour, float duration, T startValue, T endValue, Action<T> onUpdate, EasingMode easingMode, float easingFactor, Action onComplete) where T : struct
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

            return behaviour.StartCoroutine(TweenAnimation<T>(duration, startValue, endValue, onUpdate, easingMode, easingFactor, interpolate, onComplete));
        }
        #endregion Tween Value Overloads
        #region Tween Value Realtime Overloads
        /// <summary>
        /// Tweens a value from a given start value to a given end value time-scale independently.
        /// </summary>
        /// <param name="behaviour"> The MonoBehaviour the coroutine is run on. </param>
        /// <param name="duration"> How many seconds the tween will take. </param>
        /// <param name="startValue"> The starting value of the tween. </param>
        /// <param name="endValue"> The ending value of the tween. </param>
        /// <param name="onUpdate"> The delegate that's given the current value each time it's updated. </param>
        /// <returns> The coroutine of this tween. </returns>
        public static Coroutine TweenValueRealtime<T>(this MonoBehaviour behaviour, float duration, T startValue, T endValue, Action<T> onUpdate) where T : struct =>
            TweenValue<T>(behaviour, duration, startValue, endValue, onUpdate, EasingMode.Linear, 1, null);
        /// <summary>
        /// Tweens a value from a given start value to a given end value time-scale independently.
        /// </summary>
        /// <param name="behaviour"> The MonoBehaviour the coroutine is run on. </param>
        /// <param name="duration"> How many seconds the tween will take. </param>
        /// <param name="startValue"> The starting value of the tween. </param>
        /// <param name="endValue"> The ending value of the tween. </param>
        /// <param name="onUpdate"> The delegate that's given the current value each time it's updated. </param>
        /// <param name="onComplete"> The delegate that's run after the tween is complete. </param>
        /// <returns> The coroutine of this tween. </returns>
        public static Coroutine TweenValueRealtime<T>(this MonoBehaviour behaviour, float duration, T startValue, T endValue, Action<T> onUpdate, Action onComplete) where T : struct =>
            TweenValue<T>(behaviour, duration, startValue, endValue, onUpdate, EasingMode.Linear, 1, onComplete);
        /// <summary>
        /// Tweens a value from a given start value to a given end value time-scale independently.
        /// </summary>
        /// <param name="behaviour"> The MonoBehaviour the coroutine is run on. </param>
        /// <param name="duration"> How many seconds the tween will take. </param>
        /// <param name="startValue"> The starting value of the tween. </param>
        /// <param name="endValue"> The ending value of the tween. </param>
        /// <param name="onUpdate"> The delegate that's given the current value each time it's updated. </param>
        /// <param name="easingMode"> The type of easing to be applied to the tween. </param>
        /// <returns> The coroutine of this tween. </returns>
        public static Coroutine TweenValueRealtime<T>(this MonoBehaviour behaviour, float duration, T startValue, T endValue, Action<T> onUpdate, EasingMode easingMode) where T : struct =>
            TweenValue<T>(behaviour, duration, startValue, endValue, onUpdate, easingMode, 1, null);
        /// <summary>
        /// Tweens a value from a given start value to a given end value time-scale independently.
        /// </summary>
        /// <param name="behaviour"> The MonoBehaviour the coroutine is run on. </param>
        /// <param name="duration"> How many seconds the tween will take. </param>
        /// <param name="startValue"> The starting value of the tween. </param>
        /// <param name="endValue"> The ending value of the tween. </param>
        /// <param name="onUpdate"> The delegate that's given the current value each time it's updated. </param>
        /// <param name="easingMode"> The type of easing to be applied to the tween. </param>
        /// <param name="onComplete"> The delegate that's run after the tween is complete. </param>
        /// <returns> The coroutine of this tween. </returns>
        public static Coroutine TweenValueRealtime<T>(this MonoBehaviour behaviour, float duration, T startValue, T endValue, Action<T> onUpdate, EasingMode easingMode, Action onComplete) where T : struct =>
            TweenValue<T>(behaviour, duration, startValue, endValue, onUpdate, easingMode, 1, onComplete);
        /// <summary>
        /// Tweens a value from a given start value to a given end value time-scale independently.
        /// </summary>
        /// <param name="behaviour"> The MonoBehaviour the coroutine is run on. </param>
        /// <param name="duration"> How many seconds the tween will take. </param>
        /// <param name="startValue"> The starting value of the tween. </param>
        /// <param name="endValue"> The ending value of the tween. </param>
        /// <param name="onUpdate"> The delegate that's given the current value each time it's updated. </param>
        /// <param name="easingMode"> The type of easing to be applied to the tween. </param>
        /// <returns> The coroutine of this tween. </returns>
        public static Coroutine TweenValueRealtime<T>(this MonoBehaviour behaviour, float duration, T startValue, T endValue, Action<T> onUpdate, EasingMode easingMode, float easingFactor) where T : struct =>
            TweenValue<T>(behaviour, duration, startValue, endValue, onUpdate, easingMode, easingFactor, null);
        /// <summary>
        /// Tweens a value from a given start value to a given end value time-scale independently.
        /// </summary>
        /// <param name="behaviour"> The MonoBehaviour the coroutine is run on. </param>
        /// <param name="duration"> How many seconds the tween will take. </param>
        /// <param name="startValue"> The starting value of the tween. </param>
        /// <param name="endValue"> The ending value of the tween. </param>
        /// <param name="onUpdate"> The delegate that's given the current value each time it's updated. </param>
        /// <param name="easingMode"> The type of easing to be applied to the tween. </param>
        /// <param name="easingFactor"> The strength of the easing to be applied to the tween. </param>
        /// <param name="onComplete"> The delegate that's run after the tween is complete. </param>
        /// <returns> The coroutine of this tween. </returns>
        public static Coroutine TweenValueRealtime<T>(this MonoBehaviour behaviour, float duration, T startValue, T endValue, Action<T> onUpdate, EasingMode easingMode, float easingFactor, Action onComplete) where T : struct
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

            return behaviour.StartCoroutine(TweenAnimationRealtime<T>(duration, startValue, endValue, onUpdate, easingMode, easingFactor, interpolate, onComplete));
        }
        #endregion Tween Value Realtime Overloads

        #region Tween Rotation Overloads
        /// <summary>
        /// Tweens a rotation from a given start value to a given end value.
        /// </summary>
        /// <param name="behaviour"> The MonoBehaviour the coroutine is run on. </param>
        /// <param name="duration"> How many seconds the tween will take. </param>
        /// <param name="startRotation"> The starting value of the tween. </param>
        /// <param name="endRotation"> The ending value of the tween. </param>
        /// <param name="onUpdate"> The delegate that's given the current rotation each time it's updated. </param>
        /// <returns> The coroutine of this tween. </returns>
        public static Coroutine TweenRotation<T>(this MonoBehaviour behaviour, float duration, T startRotation, T endRotation, Action<T> onUpdate) where T : struct =>
            TweenRotation<T>(behaviour, duration, startRotation, endRotation, onUpdate, EasingMode.Linear, 1, null);
        /// <summary>
        /// Tweens a rotation from a given start value to a given end value.
        /// </summary>
        /// <param name="behaviour"> The MonoBehaviour the coroutine is run on. </param>
        /// <param name="duration"> How many seconds the tween will take. </param>
        /// <param name="startRotation"> The starting value of the tween. </param>
        /// <param name="endRotation"> The ending value of the tween. </param>
        /// <param name="onUpdate"> The delegate that's given the current rotation each time it's updated. </param>
        /// <param name="onComplete"> The delegate that's run after the tween is complete. </param>
        /// <returns> The coroutine of this tween. </returns>
        public static Coroutine TweenRotation<T>(this MonoBehaviour behaviour, float duration, T startRotation, T endRotation, Action<T> onUpdate, Action onComplete) where T : struct =>
            TweenRotation<T>(behaviour, duration, startRotation, endRotation, onUpdate, EasingMode.Linear, 1, onComplete);
        /// <summary>
        /// Tweens a rotation from a given start value to a given end value.
        /// </summary>
        /// <param name="behaviour"> The MonoBehaviour the coroutine is run on. </param>
        /// <param name="duration"> How many seconds the tween will take. </param>
        /// <param name="startRotation"> The starting value of the tween. </param>
        /// <param name="endRotation"> The ending value of the tween. </param>
        /// <param name="onUpdate"> The delegate that's given the current rotation each time it's updated. </param>
        /// <param name="easingMode"> The type of easing to be applied to the tween. </param>
        /// <returns> The coroutine of this tween. </returns>
        public static Coroutine TweenRotation<T>(this MonoBehaviour behaviour, float duration, T startRotation, T endRotation, Action<T> onUpdate, EasingMode easingMode) where T : struct =>
            TweenRotation<T>(behaviour, duration, startRotation, endRotation, onUpdate, easingMode, 1, null);
        /// <summary>
        /// Tweens a rotation from a given start value to a given end value.
        /// </summary>
        /// <param name="behaviour"> The MonoBehaviour the coroutine is run on. </param>
        /// <param name="duration"> How many seconds the tween will take. </param>
        /// <param name="startRotation"> The starting value of the tween. </param>
        /// <param name="endRotation"> The ending value of the tween. </param>
        /// <param name="onUpdate"> The delegate that's given the current rotation each time it's updated. </param>
        /// <param name="easingMode"> The type of easing to be applied to the tween. </param>
        /// <param name="onComplete"> The delegate that's run after the tween is complete. </param>
        /// <returns> The coroutine of this tween. </returns>
        public static Coroutine TweenRotation<T>(this MonoBehaviour behaviour, float duration, T startRotation, T endRotation, Action<T> onUpdate, EasingMode easingMode, Action onComplete) where T : struct =>
            TweenRotation<T>(behaviour, duration, startRotation, endRotation, onUpdate, easingMode, 1, onComplete);
        /// <summary>
        /// Tweens a rotation from a given start value to a given end value.
        /// </summary>
        /// <param name="behaviour"> The MonoBehaviour the coroutine is run on. </param>
        /// <param name="duration"> How many seconds the tween will take. </param>
        /// <param name="startRotation"> The starting value of the tween. </param>
        /// <param name="endRotation"> The ending value of the tween. </param>
        /// <param name="onUpdate"> The delegate that's given the current rotation each time it's updated. </param>
        /// <param name="easingMode"> The type of easing to be applied to the tween. </param>
        /// <param name="easingFactor"> The strength of the easing to be applied to the tween. </param>
        /// <returns> The coroutine of this tween. </returns>
        public static Coroutine TweenRotation<T>(this MonoBehaviour behaviour, float duration, T startRotation, T endRotation, Action<T> onUpdate, EasingMode easingMode, float easingFactor) where T : struct =>
            TweenRotation<T>(behaviour, duration, startRotation, endRotation, onUpdate, easingMode, easingFactor, null);
        /// <summary>
        /// Tweens a rotation from a given start value to a given end value.
        /// </summary>
        /// <param name="behaviour"> The MonoBehaviour the coroutine is run on. </param>
        /// <param name="duration"> How many seconds the tween will take. </param>
        /// <param name="startRotation"> The starting value of the tween. </param>
        /// <param name="endRotation"> The ending value of the tween. </param>
        /// <param name="onUpdate"> The delegate that's given the current rotation each time it's updated. </param>
        /// <param name="easingMode"> The type of easing to be applied to the tween. </param>
        /// <param name="easingFactor"> The strength of the easing to be applied to the tween. </param>
        /// <param name="onComplete"> The delegate that's run after the tween is complete. </param>
        /// <returns> The coroutine of this tween. </returns>
        public static Coroutine TweenRotation<T>(this MonoBehaviour behaviour, float duration, T startRotation, T endRotation, Action<T> onUpdate, EasingMode easingMode, float easingFactor, Action onComplete) where T : struct
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

            return behaviour.StartCoroutine(TweenAnimation<T>(duration, startRotation, endRotation, onUpdate, easingMode, easingFactor, interpolate, onComplete));
        }
        #endregion Tween Rotation Overloads
        #region Tween Rotation Realtime Overloads
        /// <summary>
        /// Tweens a rotation from a given start value to a given end value time-scale independently.
        /// </summary>
        /// <param name="behaviour"> The MonoBehaviour the coroutine is run on. </param>
        /// <param name="duration"> How many seconds the tween will take. </param>
        /// <param name="startRotation"> The starting value of the tween. </param>
        /// <param name="endRotation"> The ending value of the tween. </param>
        /// <param name="onUpdate"> The delegate that's given the current rotation each time it's updated. </param>
        /// <returns> The coroutine of this tween. </returns>
        public static Coroutine TweenRotationRealtime<T>(this MonoBehaviour behaviour, float duration, T startRotation, T endRotation, Action<T> onUpdate) where T : struct =>
            TweenRotation<T>(behaviour, duration, startRotation, endRotation, onUpdate, EasingMode.Linear, 1, null);
        /// <summary>
        /// Tweens a rotation from a given start value to a given end value time-scale independently.
        /// </summary>
        /// <param name="behaviour"> The MonoBehaviour the coroutine is run on. </param>
        /// <param name="duration"> How many seconds the tween will take. </param>
        /// <param name="startRotation"> The starting value of the tween. </param>
        /// <param name="endRotation"> The ending value of the tween. </param>
        /// <param name="onUpdate"> The delegate that's given the current rotation each time it's updated. </param>
        /// <param name="onComplete"> The delegate that's run after the tween is complete. </param>
        /// <returns> The coroutine of this tween. </returns>
        public static Coroutine TweenRotationRealtime<T>(this MonoBehaviour behaviour, float duration, T startRotation, T endRotation, Action<T> onUpdate, Action onComplete) where T : struct =>
            TweenRotation<T>(behaviour, duration, startRotation, endRotation, onUpdate, EasingMode.Linear, 1, onComplete);
        /// <summary>
        /// Tweens a rotation from a given start value to a given end value time-scale independently.
        /// </summary>
        /// <param name="behaviour"> The MonoBehaviour the coroutine is run on. </param>
        /// <param name="duration"> How many seconds the tween will take. </param>
        /// <param name="startRotation"> The starting value of the tween. </param>
        /// <param name="endRotation"> The ending value of the tween. </param>
        /// <param name="onUpdate"> The delegate that's given the current rotation each time it's updated. </param>
        /// <param name="easingMode"> The type of easing to be applied to the tween. </param>
        /// <returns> The coroutine of this tween. </returns>
        public static Coroutine TweenRotationRealtime<T>(this MonoBehaviour behaviour, float duration, T startRotation, T endRotation, Action<T> onUpdate, EasingMode easingMode) where T : struct =>
            TweenRotation<T>(behaviour, duration, startRotation, endRotation, onUpdate, easingMode, 1, null);
        /// <summary>
        /// Tweens a rotation from a given start value to a given end value time-scale independently.
        /// </summary>
        /// <param name="behaviour"> The MonoBehaviour the coroutine is run on. </param>
        /// <param name="duration"> How many seconds the tween will take. </param>
        /// <param name="startRotation"> The starting value of the tween. </param>
        /// <param name="endRotation"> The ending value of the tween. </param>
        /// <param name="onUpdate"> The delegate that's given the current rotation each time it's updated. </param>
        /// <param name="easingMode"> The type of easing to be applied to the tween. </param>
        /// <param name="onComplete"> The delegate that's run after the tween is complete. </param>
        /// <returns> The coroutine of this tween. </returns>
        public static Coroutine TweenRotationRealtime<T>(this MonoBehaviour behaviour, float duration, T startRotation, T endRotation, Action<T> onUpdate, EasingMode easingMode, Action onComplete) where T : struct =>
            TweenRotation<T>(behaviour, duration, startRotation, endRotation, onUpdate, easingMode, 1, onComplete);
        /// <summary>
        /// Tweens a rotation from a given start value to a given end value time-scale independently.
        /// </summary>
        /// <param name="behaviour"> The MonoBehaviour the coroutine is run on. </param>
        /// <param name="duration"> How many seconds the tween will take. </param>
        /// <param name="startRotation"> The starting value of the tween. </param>
        /// <param name="endRotation"> The ending value of the tween. </param>
        /// <param name="onUpdate"> The delegate that's given the current rotation each time it's updated. </param>
        /// <param name="easingMode"> The type of easing to be applied to the tween. </param>
        /// <param name="easingFactor"> The strength of the easing to be applied to the tween. </param>
        /// <returns> The coroutine of this tween. </returns>
        public static Coroutine TweenRotationRealtime<T>(this MonoBehaviour behaviour, float duration, T startRotation, T endRotation, Action<T> onUpdate, EasingMode easingMode, float easingFactor) where T : struct =>
            TweenRotation<T>(behaviour, duration, startRotation, endRotation, onUpdate, easingMode, easingFactor, null);
        /// <summary>
        /// Tweens a rotation from a given start value to a given end value time-scale independently.
        /// </summary>
        /// <param name="behaviour"> The MonoBehaviour the coroutine is run on. </param>
        /// <param name="duration"> How many seconds the tween will take. </param>
        /// <param name="startRotation"> The starting value of the tween. </param>
        /// <param name="endRotation"> The ending value of the tween. </param>
        /// <param name="onUpdate"> The delegate that's given the current rotation each time it's updated. </param>
        /// <param name="easingMode"> The type of easing to be applied to the tween. </param>
        /// <param name="easingFactor"> The strength of the easing to be applied to the tween. </param>
        /// <param name="onComplete"> The delegate that's run after the tween is complete. </param>
        /// <returns> The coroutine of this tween. </returns>
        public static Coroutine TweenRotationRealtime<T>(this MonoBehaviour behaviour, float duration, T startRotation, T endRotation, Action<T> onUpdate, EasingMode easingMode, float easingFactor, Action onComplete) where T : struct
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

            return behaviour.StartCoroutine(TweenAnimationRealtime<T>(duration, startRotation, endRotation, onUpdate, easingMode, easingFactor, interpolate, onComplete));
        }
        #endregion Tween Rotation Realtime Overloads

        private static IEnumerator TweenAnimation<T>(float duration, T startValue, T endValue, Action<T> onUpdate, EasingMode easingMode, float easingFactor, InterpolationDelegate<T> interpolate, Action onComplete = null) where T : struct
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
            if(onComplete != null) onComplete();
        }
        private static IEnumerator TweenAnimationRealtime<T>(float duration, T startValue, T endValue, Action<T> onUpdate, EasingMode easingMode, float easingFactor, InterpolationDelegate<T> interpolate, Action onComplete = null) where T : struct
        {
            float timeElapsed = 0f;
            float timeMultiplier = 1 / duration;

            while (timeElapsed < duration)
            {
                float easedProgress = Ease(easingMode, easingFactor, timeElapsed * timeMultiplier);
                onUpdate(interpolate(startValue, endValue, easedProgress));

                timeElapsed += Time.unscaledDeltaTime;
                yield return null;
            }

            onUpdate(endValue);
            if (onComplete != null) onComplete();
        }

        /// <summary>
        /// Returns an eased version of a value.
        /// </summary>
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
        /// The easing mode used for an tweens.
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