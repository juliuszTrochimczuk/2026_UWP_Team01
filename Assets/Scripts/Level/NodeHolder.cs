using System.Collections;
using System.Collections.Generic;
using Abstraction;
using UnityEngine;

public class NodeHolder : Singleton<NodeHolder>, IEnumerable
{
    [SerializeField] private List<Node> holder;

    public IEnumerator GetEnumerator() => holder.GetEnumerator();

    protected override NodeHolder CreateInstance() => this;
}
