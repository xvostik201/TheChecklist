using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheChecklist.Interfaces
{
    public interface IAudioProvider
    {
        public void PlaySound3D(Vector3 soundPosition, string audioID);


        public void PlaySound2D(string audioID);

    }
}

