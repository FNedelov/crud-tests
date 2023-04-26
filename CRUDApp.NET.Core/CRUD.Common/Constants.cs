namespace CRUD.Common
{
    public enum EventType : int
    {
        Error,
        System,
        User
    }

    public static class Constants
    {
        public const string ROLE_ADMIN = "Admin";
        public const string ROLE_USER = "User";
        public const string SYSTEM = "System";
        public const string UNKNOWN = "Unknown";

        public const string HEADER_USER = "username";
        public const string TOKEN_NAME = "access_token";
    }
}