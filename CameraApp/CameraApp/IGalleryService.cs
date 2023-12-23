namespace CameraApp
{
    public interface IGalleryService
    {
        void SaveToGallery(string name, string path);

        void OpenGallery();
    }
}