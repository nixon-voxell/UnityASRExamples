/*
This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software Foundation,
Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301, USA.

The Original Code is Copyright (C) 2020 Voxell Technologies and Contributors.
All rights reserved.
*/

using UnityEngine;
using System;
using DeepSpeechClient;
using Voxell.Inspector;

public class DeepSpeechTest : MonoBehaviour
{
  public string modelPath;
  public AudioClip clip;

  [Button]
  void Test()
  {
    DeepSpeech sttClient = new DeepSpeech(modelPath);
    float[] floatData = new float[clip.samples];
    clip.GetData(floatData, 0);
    short[] shortData = AudioFloatToInt16(floatData);

    string speechResult =  sttClient.SpeechToText(shortData, (uint)clip.samples);
    Debug.Log(speechResult);
    sttClient.Dispose();
  }

  private static short[] AudioFloatToInt16(float[] data)
  {
    Int16 maxValue = Int16.MaxValue;
    short[] shorts = new short[data.Length];

    for (int i=0; i < data.Length; i++)
    {
      shorts[i] = Convert.ToInt16 (data [i] * maxValue);
    }

    return shorts;
  }

  void Update()
  {
  }
}
