namespace Solid.App.LSPGood
{
    public interface ITakePhoto
    {
        //public override void TakePhoto();
    }
    public abstract class BasePhone
    {
        public void Call() {
            Console.WriteLine("Arama yapıldı.");    
        }
    }
    public class IPhone : BasePhone, ITakePhoto
    {
        public void TakePhoto()
        {
            Console.WriteLine("Fotoğraf çekildi.");

        }
    }
    public class Nokia3310 : BasePhone
    {
        
    }
}
