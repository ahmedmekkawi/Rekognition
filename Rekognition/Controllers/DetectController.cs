using Amazon.Rekognition.Model;
using System;
using System.Web.Http;

namespace Rekognition.Controllers
{
    public class DetectController : ApiController
    {

        [HttpPost]
        public DetectFacesResponse Detect([FromBody] string imageData)
        {
            DetectFacesResponse response = null;
            if (imageData != null)
            {
                var imageBytes = Convert.FromBase64String(imageData);

                DetectFaces df = new DetectFaces();
                response = df.Detectface(imageBytes);
            }
            return response;
        }

    }
}
