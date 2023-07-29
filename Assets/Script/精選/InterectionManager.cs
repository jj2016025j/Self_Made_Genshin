class InterectionManager{
    enum DialogueOptions{
        TALK,TRADE,DUNGEON
    }
    List<DialogueOptions> options;//0~3
    //列表內新增一個
    //新增第二個若跟第一個一樣則再選一個
    public DialogueOptions dialogueOptions;
    public void directExecutionOption(){
        ExecuteOption(dialogueOptions);
    }
    void DialogueOptions()//have option
    {
        switch(options.count)
        {
            case 0:
                //顯示...
                break;
            case 1:
                //直接跑該功能
                ExecuteOption(option[0]);
                break;
            case 2||3:
                SHOWOption(options);
                break;
            default:
                //顯示出錯...
                break;
        }
    }
    void ExecuteOption(DialogueOptions option){
        switch(option){
            case TALK:
                //開啟對話
                break;
            case TRADE:
                //開啟交易
                break;
            case DUNGEON:
                //詢問是否傳送到副本場景
                break;
        }        
    }
    void SHOWOption(List<DialogueOptions> options)
    {
        foreach(DialogueOptions option in options)
        {
            switch(option){
                case TALK:
                    //新增"對話"選項
                    break;
                case TRADE:
                    //新增"開啟交易"選項
                    break;
                case DUNGEON:
                    //新增"詢問是否傳送到副本場景"選項
                    break;
            }                        
        }
    }
}