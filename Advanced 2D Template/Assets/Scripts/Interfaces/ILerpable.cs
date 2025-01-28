namespace Interfaces
{
    public interface ILerpable<T>
    {
        public T Lerp(T b, float t);
    }
}
