using BLELedWish.Model;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;

namespace BLELedWish.Service
{
    public class LEDService : IBadgeService
    {

        public LEDService()
        {
            initDict();
        }

        public static Dictionary<char, string[]> characters = new Dictionary<char, string[]>();

        public static void initDict()
        {
            characters.Add('A',
    new string[9]{  "111111" ,
                                "100001" ,
                                "100001" ,
                                "111111" ,
                                "111111" ,
                                "100001" ,
                                "100001" ,
                                "100001" ,
                                "100001" });

            characters.Add('B',
                new string[9]{  "111110" ,
                                "100001" ,
                                "100001" ,
                                "100001" ,
                                "111110" ,
                                "100001" ,
                                "100001" ,
                                "100001" ,
                                "111110" });
            characters.Add('C',
                new string[9]{  "001111" ,
                                "010000" ,
                                "100000" ,
                                "100000" ,
                                "100000" ,
                                "100000" ,
                                "100000" ,
                                "010000" ,
                                "001110" });
            characters.Add('D',
                new string[9]{  "111110" ,
                                "100001" ,
                                "100001" ,
                                "100001" ,
                                "100001" ,
                                "100001" ,
                                "100001" ,
                                "100001" ,
                                "111110" });
            characters.Add('E',
                new string[9]{  "111111" ,
                                "100000" ,
                                "100000" ,
                                "100000" ,
                                "111110" ,
                                "100000" ,
                                "100000" ,
                                "100000" ,
                                "111111" });
            characters.Add('F',
                new string[9]{  "111111" ,
                                "100000" ,
                                "100000" ,
                                "100000" ,
                                "111110" ,
                                "100000" ,
                                "100000" ,
                                "100000" ,
                                "100000" });
            characters.Add('G',
                new string[9]{  "001110" ,
                                "010001" ,
                                "100001" ,
                                "100000" ,
                                "100000" ,
                                "100111" ,
                                "100010" ,
                                "010010" ,
                                "001100" });
            characters.Add('H',
                new string[9]{  "100001" ,
                                "100001" ,
                                "100001" ,
                                "100001" ,
                                "111111" ,
                                "100001" ,
                                "100001" ,
                                "100001" ,
                                "100001" });
            characters.Add('I',
                new string[9]{  "111111" ,
                                "001100" ,
                                "001100" ,
                                "001100" ,
                                "001100" ,
                                "001100" ,
                                "001100" ,
                                "001100" ,
                                "111111" });
            characters.Add('J',
                new string[9]{  "111111" ,
                                "000001" ,
                                "000001" ,
                                "000001" ,
                                "000001" ,
                                "000001" ,
                                "100001" ,
                                "010001" ,
                                "001110" });
            characters.Add('K',
                new string[9]{  "100001" ,
                                "100010" ,
                                "100100" ,
                                "101000" ,
                                "110000" ,
                                "101000" ,
                                "100100" ,
                                "100010" ,
                                "100001" });
            characters.Add('L',
                new string[9]{  "100000" ,
                                "100000" ,
                                "100000" ,
                                "100000" ,
                                "100000" ,
                                "100000" ,
                                "100000" ,
                                "100000" ,
                                "111111" });
            characters.Add('M',
                new string[9]{  "100001" ,
                                "110011" ,
                                "111111" ,
                                "101101" ,
                                "100001" ,
                                "100001" ,
                                "100001" ,
                                "100001" ,
                                "100001" });
            characters.Add('N',
                new string[9]{  "100001" ,
                                "110001" ,
                                "110001" ,
                                "101001" ,
                                "101001" ,
                                "100101" ,
                                "100101" ,
                                "100011" ,
                                "100001" });
            characters.Add('O',
                new string[9]{  "011110" ,
                                "100001" ,
                                "100001" ,
                                "100001" ,
                                "100001" ,
                                "100001" ,
                                "100001" ,
                                "100001" ,
                                "011110" });
            characters.Add('P',
                new string[9]{  "111100" ,
                                "100010" ,
                                "100001" ,
                                "100010" ,
                                "111100" ,
                                "100000" ,
                                "100000" ,
                                "100000" ,
                                "100000" });
            characters.Add('Q',
                new string[9]{  "011110" ,
                                "100001" ,
                                "100001" ,
                                "100001" ,
                                "100001" ,
                                "100001" ,
                                "100001" ,
                                "100010" ,
                                "011101" });
            characters.Add('R',
                new string[9]{  "111100" ,
                                "100010" ,
                                "100001" ,
                                "100010" ,
                                "111100" ,
                                "101000" ,
                                "100100" ,
                                "100010" ,
                                "100001" });
            characters.Add('S',
                new string[9]{  "011111" ,
                                "100000" ,
                                "100000" ,
                                "100000" ,
                                "011110" ,
                                "000001" ,
                                "000001" ,
                                "000001" ,
                                "111110" });
            characters.Add('T',
                new string[9]{  "111111" ,
                                "001100" ,
                                "001100" ,
                                "001100" ,
                                "001100" ,
                                "001100" ,
                                "001100" ,
                                "001100" ,
                                "001100" });
            characters.Add('U',
                new string[9]{  "100001" ,
                                "100001" ,
                                "100001" ,
                                "100001" ,
                                "100001" ,
                                "100001" ,
                                "100001" ,
                                "100001" ,
                                "011110" });
            characters.Add('V',
                new string[9]{  "100001" ,
                                "100001" ,
                                "100001" ,
                                "100001" ,
                                "010010" ,
                                "010010" ,
                                "010010" ,
                                "010010" ,
                                "001100" });
            characters.Add('W',
                new string[9]{  "100001" ,
                                "100001" ,
                                "100001" ,
                                "100001" ,
                                "100001" ,
                                "101101" ,
                                "101101" ,
                                "101101" ,
                                "110011" });
            characters.Add('X',
                new string[9]{  "100001" ,
                                "100001" ,
                                "010010" ,
                                "010010" ,
                                "001100" ,
                                "010010" ,
                                "010010" ,
                                "100001" ,
                                "100001" });
            characters.Add('Y',
                new string[9]{  "100001" ,
                                "100001" ,
                                "010010" ,
                                "010010" ,
                                "001100" ,
                                "001100" ,
                                "001100" ,
                                "001100" ,
                                "001100" });
            characters.Add('Z',
                new string[9]{  "111111" ,
                                "000001" ,
                                "000001" ,
                                "000010" ,
                                "000100" ,
                                "001000" ,
                                "010000" ,
                                "100000" ,
                                "111111" });
            characters.Add(' ',
                new string[9]{  "000000" ,
                                "000000" ,
                                "000000" ,
                                "000000" ,
                                "000000" ,
                                "000000" ,
                                "000000" ,
                                "000000" ,
                                "000000" });
        }

        public static void send(string message)
        {



            string ipAddress = "127.0.0.1"; // Adresse IP du serveur
            int port = 4433; // Numéro de port du serveur

            try
            {
                TcpClient client = new TcpClient();
                client.Connect(ipAddress, port); // Se connecter au serveur

                NetworkStream stream = client.GetStream();

                var msg = createMessage(message);
                byte[] data = Encoding.ASCII.GetBytes(msg); // Convertir la chaîne en tableau de bytes
                stream.Write(data, 0, data.Length); // Envoyer les données au serveur

                Console.WriteLine("Message envoyé avec succès !");

                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Une erreur s'est produite : " + ex.Message);
            }



        }

        public static string CreateMessage(string v)
        {
            string mess = "";
            char tempChar = ' ';
            for (int y = 0; y < 9; y++)
            {
                for (int i = 0; i < 6; i++)
                {
                    tempChar = (v.Length > i) ? v[i] : ' ';
                    mess += "0" + characters[tempChar][y];
                }
                mess += "00";
            }

            return "00000000000000000000000000000000000000000000" + mess + "00000000000000000000000000000000000000000000";
        }

        public Task SendMessage(MessageLED message)
        {
            send(message.Message);
            return Task.CompletedTask;
        }
    }
}