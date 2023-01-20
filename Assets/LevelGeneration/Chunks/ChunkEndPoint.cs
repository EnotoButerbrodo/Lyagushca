using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lyaguska.LevelGeneration
{
   public class ChunkEndPoint : MonoBehaviour
   {
      public Chunk Chunk => _chunk;
      [SerializeField] private Chunk _chunk;
      private void OnAwake()
      {
         if(_chunk == null)
            _chunk = GetComponent<Chunk>();
      }

      // private void OnValidate()
      // {
      //    if(_chunk == null)
      //       _chunk = GetComponent<Chunk>();
      // }
   }
}
