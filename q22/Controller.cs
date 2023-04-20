public class Controller
{
    public void Control(CellRobot robot)
    {
        bool up = !robot.WallUp;        // Casa acima livre
        bool left = !robot.WallLeft;    // Casa a esquerda livre
        bool rigth = !robot.WallRigth;  // Casa a direita livre
        bool down = !robot.WallDown;    // Casa a baixo livre
        
        // Implemente aqui...
    }
}