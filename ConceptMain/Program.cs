using CommonEntity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Table;
using Util;

namespace ConceptMain
{
    class Program
    {
        static void Main(string[] args)
        {
            Executor executor = new Executor();
            executor.SetDelegate();
        }
    }

    class Executor
    {
        private int start_1, end_1;
        private int start_2, end_2;
        private int start_3, end_3;
        private int start_4, end_4;
        private int start_5, end_5;
        private int start_6, end_6;
        private int start_7, end_7;
        private int start_8, end_8;
        private int start_9, end_9;
        private int start_10, end_10;

        private BaseRequest<Photo> GetRequest(int i)
        {
            return new BaseRequest<Photo>()
            {
                Request = new Photo()
                {
                    ContentBase64 = System.IO.File.ReadAllText(@"C:\FotosCaballos\foto.txt"),
                    FileName = "Caballo_" + (i+10000),
                    MymeType = "jpg",
                    PkHorse = (i+10000),
                    Url = ""
                },
                Timestamp = 1554355556,
                Token = Sha256.Generate(System.IO.File.ReadAllText(@"C:\FotosCaballos\foto.txt")+ "Caballo_" + (i+10000)+"jpg"+(i+10000).ToString()+ "1554355556")
            };
        }

        private void CallService(BaseRequest<Photo> request)
        {
            /*try
            {
                string parameters = JsonConvert.SerializeObject(request);
                HttpClient _client = new HttpClient();
                var content = new StringContent(parameters, Encoding.UTF8, "application/json");
                var uri = new Uri(string.Format("http://localhost:3000/UnicornioRS.svc/CreatePhoto", content));
                var response = _client.PostAsync(uri, content).Result;
                Console.WriteLine(response.Content.ReadAsStringAsync().Result.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }*/
            Console.WriteLine("Peticion "+request.Request.PkHorse);
            string parameters = JsonConvert.SerializeObject(request);
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:4000/UnicornioRS.svc/UploadPhoto");
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.ContentLength = parameters.Length;
            httpWebRequest.Timeout = 999999999;
            using (Stream webStream = httpWebRequest.GetRequestStream())
            using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
            {
                requestWriter.Write(parameters);
            }

            try
            {
                WebResponse webResponse = httpWebRequest.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
                using (StreamReader responseReader = new StreamReader(webStream))
                {
                    string response = responseReader.ReadToEnd();
                    Console.Out.WriteLine(response);
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("ERROR EN LLAMADO AL SERVICIO-----------------");
                Console.Out.WriteLine(e.Message);
            }

        }
        public void SetDelegate()
        {
            /*for(int i=1;i<=100;i++)
            {
                CallService(GetRequest(i));
            }*/
            ThreadStart threadStart_1 = new ThreadStart(ParallelFor_1);
            ThreadStart threadStart_2 = new ThreadStart(ParallelFor_2);
            ThreadStart threadStart_3 = new ThreadStart(ParallelFor_3);
            ThreadStart threadStart_4 = new ThreadStart(ParallelFor_4);
            ThreadStart threadStart_5 = new ThreadStart(ParallelFor_5);
            ThreadStart threadStart_6 = new ThreadStart(ParallelFor_6);
            ThreadStart threadStart_7 = new ThreadStart(ParallelFor_7);
            ThreadStart threadStart_8 = new ThreadStart(ParallelFor_8);
            ThreadStart threadStart_9 = new ThreadStart(ParallelFor_9);
            ThreadStart threadStart_10 = new ThreadStart(ParallelFor_10);
            Thread thread_1 = new Thread(threadStart_1);
            Thread thread_2 = new Thread(threadStart_2);
            Thread thread_3 = new Thread(threadStart_3);
            Thread thread_4 = new Thread(threadStart_4);
            Thread thread_5 = new Thread(threadStart_5);
            Thread thread_6 = new Thread(threadStart_6);
            Thread thread_7 = new Thread(threadStart_7);
            Thread thread_8 = new Thread(threadStart_8);
            Thread thread_9 = new Thread(threadStart_9);
            Thread thread_10 = new Thread(threadStart_10);
            start_1 = 1; end_1 = 6;
            thread_1.Start();
            start_2 = 6; end_2 = 11;
            thread_2.Start();
            start_3 = 11; end_3 = 16;
            thread_3.Start();
            start_4 = 16; end_4 = 21;
            thread_4.Start();
            start_5 = 21; end_5 = 26;
            thread_5.Start();
            start_6 = 26; end_6 = 31;
            thread_6.Start();
            start_7 = 31; end_7 = 36;
            thread_7.Start();
            start_8 = 36; end_8 = 41;
            thread_8.Start();
            start_9 = 41; end_9 = 46;
            thread_9.Start();
            start_10 = 46; end_10 = 51;
            thread_10.Start();
        }

        private void ParallelFor_1()
        {
            Parallel.For(start_1, end_1, i =>
            {
                CallService(GetRequest(i));

            });
        }
        private void ParallelFor_2()
        {
            Parallel.For(start_2, end_2, i =>
            {
                CallService(GetRequest(i));

            });
        }
        private void ParallelFor_3()
        {
            Parallel.For(start_3, end_3, i =>
            {
                CallService(GetRequest(i));

            });
        }
        private void ParallelFor_4()
        {
            Parallel.For(start_4, end_4, i =>
            {
                CallService(GetRequest(i));

            });
        }
        private void ParallelFor_5()
        {
            Parallel.For(start_5, end_5, i =>
            {
                CallService(GetRequest(i));

            });
        }

        private void ParallelFor_6()
        {
            Parallel.For(start_6, end_6, i =>
            {
                CallService(GetRequest(i));

            });
        }

        private void ParallelFor_7()
        {
            Parallel.For(start_7, end_7, i =>
            {
                CallService(GetRequest(i));

            });
        }

        private void ParallelFor_8()
        {
            Parallel.For(start_8, end_8, i =>
            {
                CallService(GetRequest(i));

            });
        }

        private void ParallelFor_9()
        {
            Parallel.For(start_9, end_9, i =>
            {
                CallService(GetRequest(i));

            });
        }

        private void ParallelFor_10()
        {
            Parallel.For(start_10, end_10, i =>
            {
                CallService(GetRequest(i));

            });
        }
    }
}