namespace SiUpin.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        bool IsAuthenticated { get; }
        string Username { get; }
        string PictureURL { get; }
    }
}