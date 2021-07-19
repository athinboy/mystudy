using NLog;
using System;
using System.Diagnostics;
using System.Runtime.ExceptionServices;

namespace ConsoleApp1
{
    class Program1
    {
        class Bussiness
        {
            public static void Call()
            {
                DBTransactionManager.Call();
            }
        }


        class AOP1
        {
            public static void Call()
            {
                Log.Call();
            }
        }
        class AOP2
        {
            public static void Call()
            {
                Log.Call();
            }
        }
        class AOP3
        {
            public static void Call()
            {
                Log.Call();
            }
        }
        class Log
        {
            public static void Call()
            {

                try
                {
                    Bussiness.Call();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Log:");
                    Console.WriteLine(ex);
                    throw;
                }

            }
        }

        interface IDBClient
        {
            public static void Call()
            {
                throw new Exception("Some Exception");
            }
        }

        class DBTransactionManagerLog
        {
            public static void Call()
            {
                try
                {
                    IDBClient.Call();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("DBTransactionManagerLog:");
                    Console.WriteLine(ex);
                    throw;
                }

            }
        }

        class DBTransactionManager
        {
            public static void Call()
            {
                DBTransactionManagerLog.Call();
            }
        }
        class DIFramework
        {
            public static void Call()
            {
                AOP2.Call();
            }
        }
        static void Main(string[] args)
        {

            try
            {
                DIFramework.Call();

            }
            catch (Exception ex)
            {

                Console.WriteLine("Main:");
                Console.WriteLine(ex);
            }

        }
    }
}
