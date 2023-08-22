using Microsoft.AspNetCore.Authorization;

namespace StudentCourseWithAuth.Authorization
{
    public class CustomCondition : IAuthorizationRequirement
    {
        public CustomCondition(int probationMonths)
        {
            ProbationMonths = probationMonths;
        }

        public int ProbationMonths { get; }
    }

    public class CustomConditionHandler : AuthorizationHandler<CustomCondition>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomCondition requirement)
        {
            if (!context.User.HasClaim(x => x.Type == "EmploymentDate"))
                return Task.CompletedTask;

            var empDate = DateTime.Parse(context.User.FindFirst(x => x.Type == "EmploymentDate").Value);
            var period = DateTime.Now - empDate;
            if (period.Days > 30 * requirement.ProbationMonths)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
