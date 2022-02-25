using Ruinum.DialogueGraph.Scripts.Node;


public class DialogueNodeLogic : NodeLogicBase
{
    private string _text;

    public override void GenerateFields(SerializedDictionaryString fields)
    {
        string test = "";
        fields.TryGetValue("Text", out test);

        _text = test;
    }

    public override void Logic()
    {
        $"Add dialogue: {_text} to Queue".Log();
        Subtitle.Singleton.AddSubtitleInQueue(_text);
    }
}