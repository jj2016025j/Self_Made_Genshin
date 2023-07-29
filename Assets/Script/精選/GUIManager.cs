class GUIManager
{
    enum ButtomFunction 
    {
        START,CLOSE
    }
    ButtomFunction buttomFunction;
    MainManager mainManager;
    void Click(){
        switch(buttomFunction)
        {
            case START:
            
                break;
            case CLOSE:
            
                break;
            case ExecutionTalkOption:
            InterectionManager.ExecuteOption(InterectionManager.DialogueOptions.Talk);
                break;
            case ExecutionTRADEOption:
            InterectionManager.ExecuteOption(InterectionManager.DialogueOptions.TRADE);
                break;
            case ExecutionDUNGEONOption:
            InterectionManager.ExecuteOption(InterectionManager.DialogueOptions.DUNGEON);
                break;
        }
    }
}
