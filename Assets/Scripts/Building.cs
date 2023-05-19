using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : GameEntity, ISelectable
{
    public bool IsSelected { get; set; }


    public void Select()
    {
        GetComponent<Renderer>().material = SelectedMaterial;
        IsSelected = true;
    }

    public void Deselect()
    {
        GetComponent<Renderer>().material = DeselectedMaterial;
        IsSelected = false;
    }

}
