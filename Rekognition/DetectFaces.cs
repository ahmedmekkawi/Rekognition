using Amazon;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Amazon.Runtime;
using System;
using System.Collections.Generic;
using System.IO;

namespace Rekognition
{
    public class DetectFaces
    {
        private const string accessKeyID = ""; // use your accessKeyId 
        private const string secretKey = ""; // use your secretKey 

        public DetectFacesResponse Detectface(byte[] imageBytes)
        {
            var credentials = new BasicAWSCredentials(accessKeyID, secretKey);

            AmazonRekognitionClient rekognitionClient = new AmazonRekognitionClient(credentials, RegionEndpoint.USEast2);
            DetectFacesResponse detectFacesResponse = null;
            try
            {
                MemoryStream ms = new MemoryStream(imageBytes);
                DetectFacesRequest detectFacesRequest = new DetectFacesRequest()
                {
                    Image = new Image()
                    {
                        Bytes = ms
                    },
                    Attributes = new List<String>() { "ALL" }
                };

                detectFacesResponse = rekognitionClient.DetectFaces(detectFacesRequest);
            }
            catch (AmazonRekognitionException e)
            {
                Console.WriteLine(e.Message);
            }

            return detectFacesResponse;
        }
    }
}