using facial_expression.WEB.Models;

namespace facial_expression.WEB.Repository
{
    public interface IImageRespository
    {
        List<Image> GetAllImages();
    }

    public class ImageRepository : IImageRespository
    {

        private List<Image> _images;

        public ImageRepository(List<Image> images) { 
            this._images = images;
        }

        public void Init()
        {
            this._images.Clear();
        }

        public List<Image> GetAllImages()
        {
            return null;
        }
    }
}
