using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProgram
{
    void Init(string[] args);

    void Tick();

    void Close();
}
