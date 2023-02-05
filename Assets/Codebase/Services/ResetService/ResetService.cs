using System.Collections.Generic;

namespace Lyaguska.Services
{
    public class ResetService : IResetService
    {
        private List<IResetable> _resetableObjects;

        public ResetService()
        {
            _resetableObjects = new List<IResetable>(16);
        }

        public ResetService(List<IResetable> resetableObjects)
        {
            _resetableObjects = resetableObjects;
        }

        public void Reset()
        {
            foreach (IResetable resetableObject in _resetableObjects)
            {
                resetableObject.Reset();
            }
        }

        public void Register(IResetable resetable)
        {
            _resetableObjects.Add(resetable);
        }
        
    }
}