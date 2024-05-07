using Assets.Scripts.Nodes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Nodes.Node;

public class Character : MonoBehaviour
{
    [SerializeField]
    private int _health;
    [SerializeField]
    private int _countAction = 2;
    [SerializeField]
    private int _moveDistance = 2;
    [SerializeField]
    private string _name;
    [SerializeField]
    private Node _node;
    public Node Node => _node;
    public string Name => _name;
    public int MoveDistance => _moveDistance * _countAction;

    public static event ClickAction OnLeftClicked;

    public void Init(Node node)
    {
        SetNode(node);
        transform.position = node.transform.position;
    }

    public void SetNode(Node node)
    {
        _node = node;
    }



    void OnMouseDown()
    {
        OnLeftClicked.Invoke(gameObject);
    }
}
