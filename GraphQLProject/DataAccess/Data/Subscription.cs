using GraphQLProject.DataAccess.Entity;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace GraphQLProject.DataAccess.Data
{
    public class Subscription
    {
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Department>> OnDepartmentCreate([Service] ITopicEventReceiver eventReceiver,CancellationToken cancalltionToken)
        {
            return await eventReceiver.SubscribeAsync<Department>("DepartmentCreated", cancalltionToken);
        }
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Employee>> OnEmployeeGet([Service] ITopicEventReceiver eventReceiver, CancellationToken cancalltionToken)
        {
            return await eventReceiver.SubscribeAsync<Employee>("ReturnedEmployee", cancalltionToken);
        }
    }
}
