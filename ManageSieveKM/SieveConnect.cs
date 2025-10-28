using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Net.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ManageSieveKM
{
    public class SieveConnect
    {
        private string _host, _email, _password;
        private int _port;
        private bool _tls, _ignoreValidation, _debug;
        private string _errors = "";

        private TcpClient client = new TcpClient();
        private NetworkStream stream;
        private SslStream sslStream;

        private string loginBase64;

        public SieveConnect(string host, string email, string password, int port, bool tls, bool ignoreValidation, bool debug)
        {
            _host = host;
            _email = email;
            _password = password;
            _port = port;
            _tls = tls;
            _ignoreValidation = ignoreValidation;
            _debug = debug;
            List<byte> loginArray = new List<byte>();
            loginArray.Add(0x00);
            loginArray.AddRange(Encoding.ASCII.GetBytes(email));
            loginArray.Add(0x00);
            loginArray.AddRange(Encoding.ASCII.GetBytes(password));
            loginBase64 = "AUTHENTICATE \"PLAIN\" \"" + Convert.ToBase64String(loginArray.ToArray()) + "\"\r\n";
        }

        public bool Connected { get => client.Connected; }
        public string Errors { get => _errors; }

        public bool Connect()
        {
            if (client.Connected)
            {
                return true;
            }
            else
            {
                string output = "";
                try
                {
                    if (this._debug)
                    {
                        Utils.LogToFile("Connecting to: " + _host + ":" + _port);
                    }
                    client = new TcpClient(_host, _port);
                    client.ReceiveTimeout = 5000;
                    stream = client.GetStream();
                    if (this._tls)
                    {
                        this._tls = false;
                        output = this.Receive();
                        if (this._debug)
                        {
                            Utils.LogToFile(output);
                            Utils.LogToFile("Send StartTLS");
                        }
                        this.Send("StartTls\r\n");
                        output = this.Receive();
                        if (this._debug)
                        {
                            Utils.LogToFile(output);
                        }
                        if (this._ignoreValidation)
                        {
                            sslStream = new SslStream(client.GetStream(), false, VerifyServerCertificate, null);
                        }
                        else
                        {
                            sslStream = new SslStream(client.GetStream());
                        }
                        //sslStream.ReadTimeout = 5000;
                        //sslStream.WriteTimeout = 5000;
                        sslStream.AuthenticateAsClient(_host);
                        this._tls = true;
                    }
                    output += this.Receive();
                    if (this._debug)
                    {
                        Utils.LogToFile(output);
                        Utils.LogToFile("Login: " + this.loginBase64);
                    }
                    this.Send(this.loginBase64);
                    if (this._debug)
                    {
                        Utils.LogToFile(output);
                        Utils.LogToFile("Login: " + this.loginBase64);
                    }
                    string output2 = this.Receive();
                    if (this._debug)
                    {
                        Utils.LogToFile(output2);
                    }
                    output += output2;
                    if (output2.Substring(0, 2) == "OK")
                    {
                        return true;
                    }
                    else
                    {
                        this._errors = output;
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    this._errors = output + Environment.NewLine + ex.Message;
                    if (ex.InnerException != null)
                    {
                        this._errors += Environment.NewLine + ex.InnerException.Message;
                    }
                    if (this._debug)
                    {
                        Utils.LogToFile(this._errors);
                    }
                    return false;
                }
            }
        }

        private static bool VerifyServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public void Send(string msg)
        {
            Byte[] dataOut = Encoding.UTF8.GetBytes(msg);
            if (this._tls)
            {
                sslStream.Write(dataOut, 0, dataOut.Length);
                //sslStream.Flush();
            }
            else
            {
                stream.Write(dataOut, 0, dataOut.Length);
                stream.Flush();
            }
        }

        public string Receive(int length = 2048)
        {
            Byte[] dataIn = new Byte[length];
            string ret = "";
            int bytes = -1;
            if (this._tls)
            {
                bytes = sslStream.Read(dataIn, 0, dataIn.Length);
                ret = Encoding.UTF8.GetString(dataIn, 0, bytes);
                sslStream.Flush();
            }
            else
            {
                bytes = stream.Read(dataIn, 0, dataIn.Length);
                ret = Encoding.UTF8.GetString(dataIn, 0, bytes);
                stream.Flush();
            }
            return ret;
        }

        public string Receive2()
        {
            byte[] buffer = new byte[2048];
            StringBuilder messageData = new StringBuilder();
            int bytes = -1;
            do
            {
                bytes = sslStream.Read(buffer, 0, buffer.Length);
                Decoder decoder = Encoding.UTF8.GetDecoder();
                char[] chars = new char[decoder.GetCharCount(buffer, 0, bytes)];
                decoder.GetChars(buffer, 0, bytes, chars, 0);
                messageData.Append(chars);
                if (messageData.ToString().IndexOf("OK \"Getscript completed.\"") != -1)
                {
                    break;
                }
            } while (bytes != 0);
            return messageData.ToString();
        }

        public List<SieveScript> GetScripts()
        {
            List<SieveScript> listScripts = new List<SieveScript>();
            if (client.Connected)
            {
                string output = "";
                try
                {
                    this.Send("Listscripts\r\n");
                    string r = this.Receive();
                    output += r;
                    foreach (string s in r.Split(new string[] { "\r\n" }, StringSplitOptions.None))
                    {
                        if (s.Length > 0)
                        {
                            if (s.Substring(0, 2) == "OK")
                            {
                                continue;
                            }
                            else
                            {
                                string[] scriptA = s.Split('\"');
                                string scriptName = scriptA[1];
                                bool active = false;
                                if (scriptA[2].Length > 0)
                                {
                                    active = true;
                                }
                                this.Send("Getscript \"" + scriptName + "\"\r\n");
                                string scriptBody = this.Receive2();
                                scriptBody = Regex.Replace(scriptBody, @"[\r\n]+", "\n");
                                string[] scriptBodyA = scriptBody.Split(new string[] { "\n" }, StringSplitOptions.None);
                                scriptBody = "";
                                for (int i = 0; i < scriptBodyA.Length; i++)
                                {
                                    if (i > 0 && i < scriptBodyA.Length - 2)
                                    {
                                        scriptBody += scriptBodyA[i] + Environment.NewLine;
                                    }
                                }
                                listScripts.Add(new SieveScript(scriptName, scriptBody, active));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    this._errors = output + Environment.NewLine + ex.Message;
                    if (ex.InnerException != null)
                    {
                        this._errors += Environment.NewLine + ex.InnerException.Message;
                    }
                    if (this._debug)
                    {
                        Utils.LogToFile(this._errors);
                    }
                }
            }
            return listScripts;
        }

        public int CountOccurrences(string source, string substring)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(substring))
                return 0;

            int count = 0;
            int index = 0;

            while ((index = source.IndexOf(substring, index)) != -1)
            {
                count++;
                index += substring.Length;
            }

            return count;
        }

        public bool SendScript(string name, string body, decimal fixBuffer)
        {
            bool ret = false;
            string r = "", output = "";
            int bodyL = body.Length + (int)fixBuffer;
            try
            {
                //check quota
                if (this._debug)
                {
                    Utils.LogToFile("HAVESPACE:");
                }
                this.Send("HAVESPACE \"" + name + "\" " + bodyL + "\r\n");
                r = this.Receive();
                if (this._debug)
                {
                    Utils.LogToFile(r);
                }
                output += "HAVESPACE: " + r;
                if (r.Length > 2)
                {
                    if (r.Substring(0, 2) != "OK")
                    {
                        this._errors = output;
                        return false;
                    }
                }
                //check script syntax
                if (this._debug)
                {
                    Utils.LogToFile("CheckScript:");
                }
                this.Send("CheckScript {" + bodyL + "+}\r\n" + body + "\r\n");
                r = this.Receive();
                if (this._debug)
                {
                    Utils.LogToFile(r);
                }
                output += "CheckScript: " + r;
                if (r.Length > 2)
                {
                    if (r.Substring(0, 2) != "OK")
                    {
                        this._errors = output;
                        return false;
                    }
                }
                //send script
                if (this._debug)
                {
                    Utils.LogToFile("Putscript:");
                }
                this.Send("Putscript \"" + name + "\" {" + bodyL + "+}\r\n" + body + "\r\n");
                r = this.Receive();
                if (this._debug)
                {
                    Utils.LogToFile(r);
                }
                output += r;
                if (r.Length > 1)
                {
                    if (r.Substring(0, 2) == "OK")
                    { 
                        ret = true;
                    }
                    else
                    {
                        this._errors = output;
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                this._errors = output + Environment.NewLine + ex.Message;
                if (ex.InnerException != null)
                {
                    this._errors += Environment.NewLine + ex.InnerException.Message;
                }
                if (this._debug)
                {
                    Utils.LogToFile(this._errors);
                }
            }
            return ret;
        }

        public void Disconnect()
        {
            if (client.Connected)
            {
                this.Send("Logout\"\r\n");
                if (this._tls)
                {
                    sslStream.Close();
                }
                stream.Close();
                client.Close();
            }
        }

        ~SieveConnect()
        {
            this.Disconnect();
        }

    }
}
