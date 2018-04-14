using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter image file path: ");
            string imageFilePath = Console.ReadLine();

            MakePredictionRequest(imageFilePath).Wait();
            
            

            Console.WriteLine("\n\n\nHit ENTER to exit...");
            Console.ReadLine();
        }

        static byte[] GetImageAsByteArray(string imageFilePath)
        {
            FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            return binaryReader.ReadBytes((int)fileStream.Length);
        }

        static double Trim(String str){
            double arr;
            int index = str.IndexOf("Weding");
            while (str[index] != '0' && str[index] != '1')
                index++;

            String temp = "";
            while (str[index] != '}')
            {
                temp = temp + str[index];
                index++;
            }

            arr = Double.Parse(temp);

            return arr;
        }

        static async Task MakePredictionRequest(string imageFilePath)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("Prediction-Key", "253b9d461c714092a4a2736b56e8cbdd");

            // Prediction URL - replace this example URL with your valid prediction URL.
            string url = "https://southcentralus.api.cognitive.microsoft.com/customvision/v1.1/Prediction/e9145736-a9e5-4fb4-ac7a-19105bd7fe5c/image?iterationId=8956777b-3065-48d1-8c96-d823bf11589a";

            HttpResponseMessage response;

            // Request body. Try this sample with a locally stored image.
            byte[] byteData = GetImageAsByteArray(imageFilePath);

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = await client.PostAsync(url, content);
                String str = await response.Content.ReadAsStringAsync();
                Console.Write(str);
                double arr = Trim(str);
                Console.Write("Wedding Probability: " + arr);
            }
        }
    }
}
