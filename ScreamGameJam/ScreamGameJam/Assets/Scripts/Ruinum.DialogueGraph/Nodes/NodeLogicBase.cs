
namespace Ruinum.DialogueGraph.Scripts.Node
{
    public abstract class NodeLogicBase
    {
        public NodeType Type;

        public abstract void GenerateFields(SerializedDictionaryString fields);
        public abstract void Logic();
    }
}