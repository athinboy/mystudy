namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class EventTest
    {

        public string name { get; set; }
        public event EventHandler? CallEvent=null;

        static void Main(string[] args)
        {

            EventTest newOne = new EventTest();
            newOne.name = "newone";
            newOne.CallEvent += OnCall;
            newOne.Call();
        }

        static void OnCall(object? sender, EventArgs eventArgs)
        {
            EventTest? et = sender as EventTest;
            Console.WriteLine(et?.name + " called");

        }
        void Call()
        {
            CallEvent?.Invoke(this, null);
            CallEvent(this, null);
       
        }


    }
}