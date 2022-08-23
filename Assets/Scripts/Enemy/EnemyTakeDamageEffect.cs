using System;
using System.Collections;
using UnityEngine;

namespace Enemy
{
    public class EnemyTakeDamageEffect : MonoBehaviour 
    {
        [SerializeField] private Material effectMaterial;
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private float speed;
        private Material originalMaterial;

        private void Start()
        {
            originalMaterial = meshRenderer.material;
        }

        public IEnumerator TakeDamageEffectCoroutine()
        {
            meshRenderer.material = effectMaterial;
            yield return new WaitForSeconds(speed);
            meshRenderer.material = originalMaterial;
        }
    }
}
