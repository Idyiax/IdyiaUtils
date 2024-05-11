using System;
using System.Collections;
using UnityEngine;

namespace IdyiaUtilities
{
    public static class Animate
    {
        #region Animators
        // Used to dynamically update a given reference value from within a coroutine. 
        private class ValueWrapper<T> { public T Value; }
        /// <summary>
        /// Animates a float from its current value to a given value.
        /// </summary>
        /// <param name="behaviour"> The MonoBehaviour the coroutine is run on. </param>
        /// <param name="duration"> How long the animation will take. </param>
        /// <param name="value"> The value (by reference) to animate. </param>
        /// <param name="endValue"> The target value of the animation. </param>
        /// <param name="easingMode"> The type of easing to be aplied to the animation. (optional) </param>
        /// <param name="easingFactor"> The strength of the easing to be aplied to the animation. (optional) </param>
        /// <returns> The coroutine of this animation. </returns>
        public static Coroutine AnimateValue(this MonoBehaviour behaviour, float duration, ref float value, float endValue, EasingMode easingMode = EasingMode.Linear, float easingFactor = 1)
        {
            ValueWrapper<float> wrapper = new ValueWrapper<float> { Value = value };
            return behaviour.StartCoroutine(AnimationValue(duration, wrapper, endValue, easingMode, easingFactor));
        }
        private static IEnumerator AnimationValue(float duration, ValueWrapper<float> wrapper, float endValue, EasingMode easingMode, float easingFactor)
        {
            float timeElapsed = 0f;
            float startValue = wrapper.Value;

            float timeMultiplier = 1 / duration;

            while (timeElapsed < duration)
            {
                float easedProgress = Ease(easingMode, easingFactor, timeElapsed * timeMultiplier);
                wrapper.Value = Mathf.Lerp(startValue, endValue, easedProgress);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            wrapper.Value = endValue;
        }
        /// <summary>
        /// Animates this behaviour's transform from its current position to a given position.
        /// </summary>
        /// <param name="behaviour"> The MonoBehaviour the coroutine is run on. </param>
        /// <param name="duration"> How long the animation will take. </param>
        /// <param name="endPosition"> The target position of the animation. </param>
        /// <param name="easingMode"> The type of easing to be aplied to the animation. (optional) </param>
        /// <param name="easingFactor"> The strength of the easing to be aplied to the animation. (optional) </param>
        /// <returns> The coroutine of this animation. </returns>
        public static Coroutine AnimatePosition(this MonoBehaviour behaviour, float duration, Vector3 endPosition, EasingMode easingMode = EasingMode.Linear, float easingFactor = 1)
        {
            return behaviour.StartCoroutine(AnimationPosition(behaviour, duration, endPosition, easingMode, easingFactor));
        }
        private static IEnumerator AnimationPosition(MonoBehaviour behaviour, float duration, Vector3 endPosition, EasingMode easingMode = EasingMode.Linear, float easingFactor = 1)
        {
            float timeElapsed = 0f;
            Vector3 startPosition = behaviour.transform.position;

            float timeMultiplier = 1 / duration;

            while (timeElapsed < duration)
            {
                float easedProgress = Ease(easingMode, easingFactor, timeElapsed * timeMultiplier);
                behaviour.transform.position = Vector3.Lerp(startPosition, endPosition, easedProgress);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            behaviour.transform.position = endPosition;
        }
        /// <summary>
        /// Animates this behaviour's transform from its current local position to a given local position.
        /// </summary>
        /// <param name="behaviour"> The MonoBehaviour the coroutine is run on. </param>
        /// <param name="duration"> How long the animation will take. </param>
        /// <param name="endPosition"> The target local position of the animation. </param>
        /// <param name="easingMode"> The type of easing to be aplied to the animation. (optional) </param>
        /// <param name="easingFactor"> The strength of the easing to be aplied to the animation. (optional) </param>
        /// <returns> The coroutine of this animation. </returns>
        public static Coroutine AnimateLocalPosition(this MonoBehaviour behaviour, float duration, Vector3 endPosition, EasingMode easingMode = EasingMode.Linear, float easingFactor = 1)
        {
            return behaviour.StartCoroutine(AnimationLocalPosition(behaviour, duration, endPosition, easingMode, easingFactor));
        }
        private static IEnumerator AnimationLocalPosition(MonoBehaviour behaviour, float duration, Vector3 endPosition, EasingMode easingMode = EasingMode.Linear, float easingFactor = 1)
        {
            float timeElapsed = 0f;
            Vector3 startPosition = behaviour.transform.localPosition;

            float timeMultiplier = 1 / duration;

            while (timeElapsed < duration)
            {
                float easedProgress = Ease(easingMode, easingFactor, timeElapsed * timeMultiplier);
                behaviour.transform.localPosition = Vector3.Lerp(startPosition, endPosition, easedProgress);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            behaviour.transform.localPosition = endPosition;
        }
        /// <summary>
        /// Animates this behaviour's transform from its current rotation to a given rotation.
        /// </summary>
        /// <param name="behaviour"> The MonoBehaviour the coroutine is run on. </param>
        /// <param name="duration"> How long the animation will take. </param>
        /// <param name="endRotation"> The target rotation of the animation. </param>
        /// <param name="easingMode"> The type of easing to be aplied to the animation. (optional) </param>
        /// <param name="easingFactor"> The strength of the easing to be aplied to the animation. (optional) </param>
        /// <returns> The coroutine of this animation. </returns>
        public static Coroutine AnimateRotation(this MonoBehaviour behaviour, float duration, Quaternion endRotation, EasingMode easingMode = EasingMode.Linear, float easingFactor = 1)
        {
            return behaviour.StartCoroutine(AnimationRotation(behaviour, duration, endRotation, easingMode, easingFactor));
        }
        private static IEnumerator AnimationRotation(MonoBehaviour behaviour, float duration, Quaternion endRotation, EasingMode easingMode = EasingMode.Linear, float easingFactor = 1)
        {
            float timeElapsed = 0f;
            Quaternion startRotation = behaviour.transform.rotation;

            float timeMultiplier = 1 / duration;

            while (timeElapsed < duration)
            {
                float easedProgress = Ease(easingMode, easingFactor, timeElapsed * timeMultiplier);
                behaviour.transform.rotation = Quaternion.Slerp(startRotation, endRotation, easedProgress);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            behaviour.transform.rotation = endRotation;
        }
        /// <summary>
        /// Animates this behaviour's transform from its current local rotation to a given local rotation.
        /// </summary>
        /// <param name="behaviour"> The MonoBehaviour the coroutine is run on. </param>
        /// <param name="duration"> How long the animation will take. </param>
        /// <param name="endRotation"> The target local rotation of the animation. </param>
        /// <param name="easingMode"> The type of easing to be aplied to the animation. (optional) </param>
        /// <param name="easingFactor"> The strength of the easing to be aplied to the animation. (optional) </param>
        /// <returns> The coroutine of this animation. </returns>
        public static Coroutine AnimateLocalRotation(this MonoBehaviour behaviour, float duration, Quaternion endRotation, EasingMode easingMode = EasingMode.Linear, float easingFactor = 1)
        {
            return behaviour.StartCoroutine(AnimationLocalRotation(behaviour, duration, endRotation, easingMode, easingFactor));
        }
        private static IEnumerator AnimationLocalRotation(MonoBehaviour behaviour, float duration, Quaternion endRotation, EasingMode easingMode = EasingMode.Linear, float easingFactor = 1)
        {
            float timeElapsed = 0f;
            Quaternion startRotation = behaviour.transform.localRotation;

            float timeMultiplier = 1 / duration;

            while (timeElapsed < duration)
            {
                float easedProgress = Ease(easingMode, easingFactor, timeElapsed * timeMultiplier);
                behaviour.transform.localRotation = Quaternion.Slerp(startRotation, endRotation, easedProgress);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            behaviour.transform.localRotation = endRotation;
        }
        /// <summary>
        /// Animates this behaviour's transform from its current local scale to a given local scale.
        /// </summary>
        /// <param name="behaviour"> The MonoBehaviour the coroutine is run on. </param>
        /// <param name="duration"> How long the animation will take. </param>
        /// <param name="endScale"> The target local scale of the animation. </param>
        /// <param name="easingMode"> The type of easing to be aplied to the animation. (optional) </param>
        /// <param name="easingFactor"> The strength of the easing to be aplied to the animation. (optional) </param>
        /// <returns> The coroutine of this animation. </returns>
        public static Coroutine AnimateLocalScale(this MonoBehaviour behaviour, float duration, Vector3 endScale, EasingMode easingMode = EasingMode.Linear, float easingFactor = 1)
        {
            return behaviour.StartCoroutine(AnimationLocalScale(behaviour, duration, endScale, easingMode, easingFactor));
        }
        private static IEnumerator AnimationLocalScale(MonoBehaviour behaviour, float duration, Vector3 endScale, EasingMode easingMode = EasingMode.Linear, float easingFactor = 1)
        {
            float timeElapsed = 0f;
            Vector3 startScale = behaviour.transform.localScale;

            float timeMultiplier = 1 / duration;

            while (timeElapsed < duration)
            {
                float easedProgress = Ease(easingMode, easingFactor, timeElapsed * timeMultiplier);
                behaviour.transform.localScale = Vector3.Lerp(startScale, endScale, easedProgress);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            behaviour.transform.localScale = endScale;
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
        #endregion Animators
    }
}