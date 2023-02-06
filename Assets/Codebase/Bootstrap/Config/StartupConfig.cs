using UnityEditor;
using UnityEngine;

namespace Codebase.Bootstrap.Config
{
    [CreateAssetMenu(fileName = "StartupConfig", menuName = "Config/Startup", order = 0)]
    public class StartupConfig : ScriptableObject
    {
        public Vector2 ActorStartPosition => _actorStartPosition;
        public Vector2 GenerationStartPosition => _generationStartPosition;
        
        [SerializeField] private Vector3 _actorStartPosition;
        [SerializeField] private Vector3 _generationStartPosition;

#if UNITY_EDITOR
        [ContextMenu("Collect")]
        private void Collect()
        {
            _actorStartPosition = GameObject.Find(nameof(ActorStartPosition)).transform.position;
            _generationStartPosition = GameObject.Find(nameof(GenerationStartPosition)).transform.position;
        }
#endif
        
    }
}