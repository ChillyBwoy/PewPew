using UnityEngine;
using Leopotam.Ecs;

using PewPew.Components;
using PewPew.Components.Input;
using PewPew.Components.Tags;
using PewPew.UnityComponents;

namespace PewPew.Systems.Player
{
    sealed class PlayerRotationSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, CharacterComponent, RotationComponent, InputAxisComponent> _filter = null;

        private readonly StaticData _staticData = null;

        private float _rotationX;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref CharacterComponent character = ref _filter.Get2(i);
                ref RotationComponent rotation = ref _filter.Get3(i);
                ref InputAxisComponent axis = ref _filter.Get4(i);

                _rotationX += axis.value.x;
                _rotationX = Mathf.Repeat(_rotationX, 360);
                rotation.value = Quaternion.Euler(0, _rotationX, 0);
            }
        }
    }
}

/*
ref CharacterComponent character = ref _filter.Get2(i);
ref InputAxisComponent axis = ref _filter.Get3(i);

_rotationX += axis.value.x;
_rotationX = Mathf.Clamp(_rotationX, -45f, 45f);
_rotationY -= axis.value.y;
_rotationY = Mathf.Clamp(_rotationY, -50f, 50f);

// character.head.localRotation = Quaternion.Euler(_rotationY, 0, 0);

/**
* Drunk rotation
* Quaternion desiredRotation = Quaternion.Euler(_rotationY, _rotationX, 0);
* character.head.rotation = Quaternion.Slerp(character.head.rotation, desiredRotation, Time.deltaTime);
*/