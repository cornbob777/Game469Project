using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class DialogueEditorWindow : EditorWindow
{
    private List<DialogueNode> nodes = new List<DialogueNode>();
    private Vector2 scrollPosition;
    private GUIStyle nodeStyle;
    private DialogueNode selectedNode = null;
    private Vector2 dragOffset;
    private bool isConnectingNodes = false;
    private DialogueNode startNode = null;
    private Choice selectedChoice = null;

    [MenuItem("Window/Dialogue Editor")]
    public static void OpenWindow()
    {
        DialogueEditorWindow window = GetWindow<DialogueEditorWindow>("Dialogue Editor");
        window.Show();
    }

    private void OnEnable()
    {
        nodeStyle = new GUIStyle();
        nodeStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/node1.png") as Texture2D;
        nodeStyle.border = new RectOffset(12, 12, 12, 12);
        LoadNodes();
    }

    private void OnGUI()
    {
        DrawToolbar();         // Draw the toolbar for interaction mode
        DrawNodes();           // Draw all the nodes on the editor
        DrawConnections();     // Draw connections between nodes to represent choices
        DrawNodeDetails();     // Display details of the selected node for editing
        ProcessEvents(Event.current);
    }

    private void DrawToolbar()
    {
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Save Dialogue", GUILayout.Width(100)))
        {
            SaveNodes();
        }
        if (GUILayout.Button("Load Nodes", GUILayout.Width(100)))
        {
            LoadNodes();
        }
        isConnectingNodes = GUILayout.Toggle(isConnectingNodes, "Connect Nodes", "Button", GUILayout.Width(120));
        GUILayout.EndHorizontal();
    }

    private void DrawNodes()
    {
        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, GUILayout.Width(position.width), GUILayout.Height(position.height));

        foreach (var node in nodes)
        {
            GUILayout.BeginArea(new Rect(node.position, new Vector2(200, 150)), nodeStyle);

            if (selectedNode == node)
            {
                node.characterName = EditorGUILayout.TextField("Character", node.characterName);
                node.dialogueText = EditorGUILayout.TextField("Dialogue", node.dialogueText);

                // Display choices in the node
                for (int i = 0; i < node.choices.Count; i++)
                {
                    GUILayout.BeginHorizontal();
                    node.choices[i].choiceText = EditorGUILayout.TextField(node.choices[i].choiceText);
                    if (GUILayout.Button("Link", GUILayout.Width(50)))
                    {
                        selectedChoice = node.choices[i];
                        startNode = node; // Prepare to link this choice
                    }
                    if (GUILayout.Button("X", GUILayout.Width(20)))
                    {
                        node.choices.RemoveAt(i); // Remove the choice
                    }
                    GUILayout.EndHorizontal();
                }

                if (GUILayout.Button("Add Choice"))
                {
                    node.choices.Add(new Choice { choiceText = "New Choice" });
                }
            }
            else
            {
                EditorGUILayout.LabelField("Character: " + node.characterName);
                EditorGUILayout.LabelField("Dialogue: " + node.dialogueText);
            }

            GUILayout.EndArea();

            HandleNodeEvents(node);
        }

        EditorGUILayout.EndScrollView();
    }

    private void DrawConnections()
    {
        foreach (var node in nodes)
        {
            if (node.choices == null) continue;

            foreach (Choice choice in node.choices)
            {
                if (choice != null && choice.nextNode != null)
                {
                    Handles.DrawLine(node.position + new Vector2(100, 50), choice.nextNode.position + new Vector2(100, 50));
                }
            }
        }
    }

    private void DrawNodeDetails()
    {
        if (selectedNode != null)
        {
            GUILayout.BeginArea(new Rect(10, position.height - 150, position.width - 20, 140), nodeStyle);
            EditorGUILayout.LabelField("Edit Node", EditorStyles.boldLabel);
            selectedNode.characterName = EditorGUILayout.TextField("Character Name:", selectedNode.characterName);
            selectedNode.dialogueText = EditorGUILayout.TextField("Dialogue Text:", selectedNode.dialogueText);
            GUILayout.EndArea();
        }
    }

    private void HandleNodeEvents(DialogueNode node)
    {
        Event e = Event.current;
        Rect nodeRect = new Rect(node.position, new Vector2(200, 150));

        if (nodeRect.Contains(e.mousePosition))
        {
            if (e.type == EventType.MouseDown && e.button == 0) // Left-click to select the node
            {
                if (isConnectingNodes && startNode != null && selectedChoice != null)
                {
                    selectedChoice.nextNode = node; // Link the choice to this node
                    startNode = null;
                    selectedChoice = null;
                }
                else
                {
                    selectedNode = node; // Regular node selection
                    dragOffset = node.position - e.mousePosition;
                }
                GUI.changed = true;
            }
        }

        if (e.type == EventType.MouseDrag && selectedNode == node)
        {
            selectedNode.position = e.mousePosition + dragOffset;
            GUI.changed = true;
        }
    }

    private void ProcessEvents(Event e)
    {
        if (e.type == EventType.MouseDown && e.button == 1) // Right-click to add a node
        {
            Vector2 mousePos = e.mousePosition;
            AddNode(mousePos);
        }
    }

    private void AddNode(Vector2 position)
    {
        DialogueNode newNode = CreateInstance<DialogueNode>();
        newNode.characterName = "New Character";
        newNode.dialogueText = "New Dialogue";
        newNode.position = position;
        newNode.choices = new List<Choice>();
        nodes.Add(newNode);
    }

    private void SaveNodes()
    {
        foreach (var node in nodes)
        {
            AssetDatabase.CreateAsset(node, $"Assets/Resources/DialogueNodes/{node.characterName}_{System.Guid.NewGuid()}.asset");
        }
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    private void LoadNodes()
    {
        nodes = new List<DialogueNode>(Resources.LoadAll<DialogueNode>("DialogueNodes"));
    }
}
