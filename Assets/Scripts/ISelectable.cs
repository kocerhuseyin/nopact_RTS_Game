using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelectable
{
    bool IsSelected { get; set; }

    void Select();
    void Deselect();
}
