using UnityEngine;
using System.Collections;


public interface IPointable
{

    void PointerEnter();

    void PointerExit();

}

public interface IClickable : IPointable
{
    void Clicked();
}

