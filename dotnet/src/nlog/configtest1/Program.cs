using NLog;
using System;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {


        static void Method3()
        {

            try
            {
                throw new Exception("Exception3");

            }
            catch (Exception ex)
            {
                logger.Error(ex);

                StackTrace stackTrace = new StackTrace(ex);
                StackFrame[] frames = stackTrace.GetFrames();
                for (int i = 0; i < frames.Length; i++)
                {
                    StackFrame sf = frames[i];
                }

                stackTrace = new StackTrace(true);
                  frames = stackTrace.GetFrames();
                for (int i = 0; i < frames.Length; i++)
                {
                    StackFrame sf = frames[i];
                }



                if (Debugger.IsAttached)
                {
                    Debug.Write(ex);
                }
                Console.Write(ex);

            }

            throw new Exception("Exception");
        }

        static void Method2()
        {
            Method3();
            throw new Exception("Exception");
        }

        static void Method1()
        {
            Method2();
        }



        static Logger logger;

        static void Main(string[] args)
        {

            logger = LogManager.GetCurrentClassLogger();

            try
            {
                logger.Info("hello world!");
                Method1();

            }
            catch (Exception e)
            {
                StackTrace stackTrace = new StackTrace(e);
                logger.Error(e, nameof(Program.Main));

            }
            finally
            {
                LogManager.DisableLogging();
            }






        }
    }
}
