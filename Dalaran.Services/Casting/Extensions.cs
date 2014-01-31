namespace Dalaran.Services.Casting
{
    public static class Extensions
    {   
        public static T As<T>(this object o)
        {
            return (T)o;
        }
    }
}
