using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PathFinding
{
    public struct Node {
        int column, row;
        bool free;
    };

    public struct Path {
        Node node;
    };

    private struct InternalNode {
        double f, g, h;
        Node node;
    };

    // Returns true if a path was found, false if no path was found
    public static bool GetPath( Node startNode, Node endNode ) {
        List<InternalNode> openList = new List<InternalNode>();
        List<InternalNode> closedList = new List<InternalNode>();
        return false;
    }
}
