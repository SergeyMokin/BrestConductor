using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using SpamBotVK.Models;
using SpamBotVK.Repository;
using System.Threading;
namespace SpamBotVK.Service
{
    class BotService
    {
        private IRepository repository;

        public BotService(IRepository _repository)
        {
            repository = _repository;
        }

        public void StartSpam()
        {
            var request = WebRequest.Create(@"http://localhost:63611/");
            request.ContentType = "application/json";
            request.Method = "POST";
            LastSendTime = DateTime.Now;
            int count = 0;
            var rnd1 = new Random();
            var rnd2 = new Random();
            var rnd3 = new Random();
            var db = repository.GetBusstations();
            while (true)
            {
                if (count == 0 || (LastSendTime.Hour > 7 && LastSendTime.Hour < 22))
                {
                    LastSendTime = DateTime.Now;
                    var post = generatePost(db, rnd1, rnd2, rnd3);
                    count++;
                    var _post = POST(@"http://localhost:63611/api/posts", $"Id={post.Id}&Date={post.Date}&Message={post.Message}&LastConfirmDate={post.LastConfirmDate}");
                    Thread.Sleep(10800000);
                }
            }

        }

        private string POST(string Url, string Data)
        {
            string _out = string.Empty;
            try
            {
                System.Net.WebRequest req = System.Net.WebRequest.Create(Url);
                req.Method = "POST";
                req.Timeout = 100000;
                req.ContentType = "application/x-www-form-urlencoded";
                byte[] sentData = System.Text.Encoding.GetEncoding("utf-8").GetBytes(Data);
                req.ContentLength = sentData.Length;
                System.IO.Stream sendStream = req.GetRequestStream();
                sendStream.Write(sentData, 0, sentData.Length);
                sendStream.Close();
                var res = req.GetResponse();
                var ReceiveStream = res.GetResponseStream();
                System.IO.StreamReader sr = new System.IO.StreamReader(ReceiveStream);
                Char[] read = new Char[256];
                int count = sr.Read(read, 0, 256);
                while (count > 0)
                {
                    String str = new String(read, 0, count);
                    _out += str;
                    count = sr.Read(read, 0, 256);
                }
            }
            catch (Exception e)
            {
                return e.ToString();
            }
            return _out == string.Empty ? "Not send" : _out;
        }

        private string generateMessage(Dictionary<int, Tuple<string, string>> db, Random rnd1, Random rnd2, Random rnd3)
        {
            int keyIndex = rnd1.Next(1, db.Count());
            int number = rnd2.Next(0, 6);
            int keyChoise = rnd3.Next(0, 2);
            string result = "";
            switch (number)
            {
                case 0: result = keyChoise == 1 ? $"{db[keyIndex].Item1}-{db[keyIndex].Item2} чисто" : $"есть кто {db[keyIndex].Item1}-{db[keyIndex].Item2}?"; break;
                case 1: result = keyChoise == 1 ? $"стоят {db[keyIndex].Item1}" : $"{db[keyIndex].Item1} дежурят"; break;
                case 2: result = keyChoise == 1 ? $"{db[keyIndex].Item1} в сторону {db[keyIndex].Item2}" : $"стоят на остановке {db[keyIndex].Item1} - {db[keyIndex].Item2}"; break;
                case 3: result = keyChoise == 1 ? $"{db[keyIndex].Item2}-{db[keyIndex].Item1} чисто" : $"есть кто {db[keyIndex].Item2}-{db[keyIndex].Item1}?"; break;
                case 4: result = keyChoise == 1 ? $"стоят {db[keyIndex].Item2}" : $"{db[keyIndex].Item2} дежурят"; break;
                case 5: result = keyChoise == 1 ? $"{db[keyIndex].Item2} в сторону {db[keyIndex].Item1}" : $"стоят на остановке {db[keyIndex].Item2} - {db[keyIndex].Item1}"; break;
                default: break;
            }
            return result;
        }

        private Post generatePost(Dictionary<int, Tuple<string, string>> db, Random rnd1, Random rnd2, Random rnd3)
        {
            var message = generateMessage(db, rnd1, rnd2, rnd3);
            return new Post
            {
                Id = 1,
                Date = DateTime.Now,
                Message = message,
                LastConfirmDate = DateTime.Now
            };
        }

        private DateTime LastSendTime { get; set; }
    }
}