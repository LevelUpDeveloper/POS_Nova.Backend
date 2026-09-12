namespace POS_Nova.Api.Extensions
{
    public static class PoliciesExtensions
    {

        public static IServiceCollection AddAuthorizationPolicies(
            this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(
                    "RequireAdmin",
                    policy => policy.RequireRole("Admin"));

                options.AddPolicy(
                    "RequireManager",
                    policy => policy.RequireRole("Manager"));

                options.AddPolicy(
                    "CanManageProducts",
                    policy => policy.RequireRole("Admin", "Manager"));

                options.AddPolicy(
                    "CanManageUser",
                    policy => policy.RequireRole("Admin", "Manager"));
            });

            return services;
        }

    }
}
