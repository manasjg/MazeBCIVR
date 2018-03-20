using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

public class NeuroskyConn : MonoBehaviour {
    TcpClient client;
    Stream stream;
    byte[] buffer = new byte[2048];
    int bytesRead;
    // Building command to enable JSON output from ThinkGear Connector (TGC)
    byte[] myWriteBuffer = Encoding.ASCII.GetBytes(@"{""enableRawOutput"": true,
            ""format"": ""Json""}");
    public int attention;
    public int meditation;
    public int blink;
    private void Start()
    {
        try
        {
            client = new TcpClient("127.0.0.1", 13854);
            stream = client.GetStream();
            // Sending configuration packet to TGC
            if (stream.CanWrite)
            {
                stream.Write(myWriteBuffer, 0, myWriteBuffer.Length);
            }
        }
        catch (SocketException se) { }
    }
    public void ReadSocket()
    {
        try
        {
            
           
            if (stream.CanRead)
            {
                    bytesRead = stream.Read(buffer, 0, 2048);
                string[] packets = Encoding.UTF8.GetString(buffer, 0,
                bytesRead).Split('\r');
                
                
                    foreach (string s in packets)
                    {
                    
                    if (s.Length > 190)
                    {
                        
                        attention = GetAttention(s);
                        meditation = GetMeditation(s);

                    }
                    if (s.Contains("blink"))
                    {
                        Debug.Log(s);
                        blink = GetBlink(s);
                        Debug.Log(blink);
                    }
                    }

               
                
            }
        }
        catch (SocketException se) { }
        
    }
    static int GetAttention(string s)
    {
        int attI = s.IndexOf("attention");

        string att = " ";
        if (s[attI + 12] == ',')
        {
            att = s.Substring((s.IndexOf("attention") + 11), 1);
        }
        else if (s[attI + 13] == ',')
        {
            att = s.Substring((s.IndexOf("attention") + 11), 2);
        }
        else if (s[attI + 14] == ',')
        {
            att = s.Substring((s.IndexOf("attention") + 11), 3);
        }
        //string med = s.Substring((s.IndexOf("meditation") + 12), 2);
        return int.Parse(att);

    }
    static int GetMeditation(string s)
    {
        int attI = s.IndexOf("meditation");

        string med = " ";
        if (s[attI + 13] == '}')
        {
            med = s.Substring((s.IndexOf("meditation") + 12), 1);
        }
        else if (s[attI + 14] == '}')
        {
            med = s.Substring((s.IndexOf("meditation") + 12), 2);
        }
        else if (s[attI + 15] == '}')
        {
            med = s.Substring((s.IndexOf("meditation") + 12), 3);
        }
        //string med = s.Substring((s.IndexOf("meditation") + 12), 2);
        return int.Parse(med);

    }
    static int GetBlink(string s)
    {
        int attI = s.IndexOf("blinkStrength");
        string blk = " ";
        if(s[attI+17]== '}')
        {
            blk =s.Substring(attI+15, 2);
        }
        else if (s[attI + 18] == '}')
        {
            blk = s.Substring(attI + 15, 3);
        }
        return int.Parse(blk);
        
    }
}

