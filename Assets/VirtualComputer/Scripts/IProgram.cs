using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProgram
{
    void Init();

    void Tick();

    void Close();
}
