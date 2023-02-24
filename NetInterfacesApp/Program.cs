namespace NetInterfacesApp
{
    interface IMove
    {
        const int index = 100;
        static int maxSpeed;
        void Move(int dx, int dy);
        string Title { set; get; }
        
        void PrintTitle()
        {
            Console.WriteLine($"Title: {Title}");
        }
        //delegate void MoveHandler(object sender, EventArgs e);
        // event MoveHandler MoveEvent

        event Action<object, EventArgs> MoveEvent;
    }
    class Point : IMove, ICloneable
    {
        public int X { set; get; }
        public int Y { set; get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
            Title = "Point";
        }

        public string Title { get; set; }

        public event Action<object, EventArgs> MoveEvent;

        public void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }

        public void Print()
        {
            Console.WriteLine($"x = {X}, y = {Y}");
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }

    interface IAction
    {
        void ActionExecute();
    }

    class BaseClass : IAction
    {
        public void ActionExecute()
        {
            Console.WriteLine("Base Action Execute");
        }
        void IAction.ActionExecute() 
        {
            ActionExecute();
        }
    }

    class SecondClass : IAction
    {
        public void ActionExecute()
        {
            Console.WriteLine("Second Action Execute");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(IMove.index);
            //IMove.maxSpeed = 200;

            //Point point1 = new(10, 20);
            //point1.Move(5, 5);
            //point1.Print();
            //(point1 as IMove).PrintTitle();

            //IMove point2 = new Point(30, 40);
            //point2.Move(2, 3);
            //((Point)point2).Print();
            //(point2 as Point).Print();
            //point2.PrintTitle();

            BaseClass obj1 = new BaseClass();
            obj1.ActionExecute();

            IAction obj2 = new BaseClass();
            obj2.ActionExecute();
        }
    }
}