class unit{
    private void OnEnable() {
        GameManager.endGameObservers.Remove(this);

    }
    private void OnDisable() {
        GameManager.endGameObservers.Remove(this);
    }
    void EndNotufy(){
        
    }
    //如果可互動則加上InterectionManager的腳本跟trigger物件
}
