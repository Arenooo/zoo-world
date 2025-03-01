using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using ZooWorld.Animals;

namespace ZooWorld.Views.Animals
{
    public class PredatorCanvasView : AnimalCanvasView
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _killFadeDuration = 1;
        [SerializeField] private float _killFadeDelay = 1;

        protected Predator Predator { get; private set; }

        private Tween _fadeTween;

        public override void Initialize(Animal owner)
        {
            base.Initialize(owner);

            if (Animal is not Predator predator)
                throw new Exception("The animal is not a predator");

            Predator = predator;
            Predator.Killed += OnKilled;
            _canvasGroup.alpha = 0;
        }

        protected virtual void OnKilled(Animal animal)
        {
            _fadeTween?.Kill();
            _canvasGroup.alpha = 1;
            _fadeTween = _canvasGroup.DOFade(0, _killFadeDuration).SetDelay(_killFadeDelay);
        }
    }
}
