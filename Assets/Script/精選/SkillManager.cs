using UnityEngine;

public class SkillManager
{
    public enum SkillSerialNumber
    {
        A,B,C,D,E
    }
    SkillSerialNumber skillSerialNumber;
    void Execution(SkillSerialNumber skillSerialNumber)
    {
        switch(skillSerialNumber)
        {
            case A:
                //A
                break;
            case B:
                //B
                break;
            case C:
                //C
                break;
            case D:
                //D
                break;
            case E:
                //E
                
                break;
        }
    }
    public void directionalSkills()
    {
        Vector3 offset = new Vector3(0, 1, 0);
        Instantiate(skill[0], transform.position + offset, transform.rotation, transform);//�аO�����鬰������
    }

}