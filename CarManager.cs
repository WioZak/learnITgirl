﻿using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;

namespace DesktopApp
{
    class CarManager
    {
        public string IP { get; set; }
        public int Port { get; set; }


        TcpClient tcpclnt = new TcpClient();
        public void Connect(string ip, int port) 
        {
            try
            {
                tcpclnt.Connect(ip, port);
            }
            catch (Exception e)
            {
                Console.WriteLine("Connection error...  " + e.StackTrace); // @todo change this to dialogbox
            }
        }

        private void SendCommand(string command)
        {
            //Enter the string to be transmitted:
            string str = command;
            Stream stm = tcpclnt.GetStream();
            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] b = asen.GetBytes(str);
            //Transmitting.....
            stm.Write(b, 0, b.Length);
        }
        public void Go()
        {
            SendCommand("g");
        }

        public void Stop()
        {
            SendCommand("s");
        }

        public void Disconnect()
        {
            tcpclnt.Close();
        }

    }
}
