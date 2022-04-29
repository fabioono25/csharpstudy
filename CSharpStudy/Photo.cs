namespace CSharpStudy
{
    public class Photo
    {
        public static Photo Load(string path)
        {
            return new Photo();
        }

        public void Save()
        {

        }
    }

    public class PhotoProcessor
    {
        public delegate void PhotoFilterHandler(Photo photo);
        //public void Process(string path, PhotoFilterHandler filterHandler){
        public void Process(string path, Action<Photo> filterHandler)
        {
            //System.Action<>
            var photo = Photo.Load(path);

            //not extensible
            // var filters = new PhotoFilters();
            // filters.Resize(photo);
            filterHandler(photo); //extensible

            photo.Save();
        }
    }

    public class PhotoFilters
    {
        public PhotoFilters()
        {
        }

        public void Resize(Photo photo)
        {
            System.Console.WriteLine("resize");
        }

        public void ApplyContrast(Photo photo)
        {
            System.Console.WriteLine("contrast");
        }
    }
}
