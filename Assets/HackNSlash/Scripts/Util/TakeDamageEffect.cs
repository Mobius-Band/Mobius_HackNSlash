using System;
using System.Collections;
using UnityEngine;

namespace Enemy
{
    public class TakeDamageEffect : MonoBehaviour 
    {
        [SerializeField] private Material _effectMaterial;
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private float _speed;
        private Material _originalMaterial;

        private void Awake()
        {
            _originalMaterial = _meshRenderer.material;
        }

        public IEnumerator TakeDamageEffectCoroutine()
        {
            _meshRenderer.material = _effectMaterial;
            yield return new WaitForSeconds(_speed);
            _meshRenderer.material = _originalMaterial;
        }
    }
}
