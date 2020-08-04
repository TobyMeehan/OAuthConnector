using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TobyMeehan.OAuth.Collections;
using TobyMeehan.OAuth.Controllers;

namespace TobyMeehan.OAuth.Models
{
    public class User : UserBase, IUser
    {
        private readonly IUserController _controller;

        public User(IUserController controller)
        {
            _controller = controller;
        }

        public static async Task<User> CreateAsync(UserBase @base, IUserController controller, CancellationToken cancellationToken)
        {
            var user = new User(controller)
            {
                Id = @base.Id,
                Username = @base.Username,
                Balance = @base.Balance,
                Roles = @base.Roles.ToEntityCollection<IRole, RoleBase>(r => new Role(r))
            };

            user.Transactions = await controller.GetTransactionsAsync(@base.Id, cancellationToken);
            user.Downloads = await controller.GetDownloadsAsync(@base.Id, cancellationToken);

            return user;
        }

        public static async Task<IEntityCollection<T>> CreateCollectionAsync<T>(IEnumerable<UserBase> collection, IUserController controller, CancellationToken cancellationToken) where T : IEntity
        {
            var entityCollection = new EntityCollection<User>();

            foreach (var user in collection)
            {
                entityCollection.Add(await CreateAsync(user, controller, cancellationToken));
            }

            return entityCollection.Cast<T>().ToEntityCollection();
        }

        public new IEntityCollection<IRole> Roles { get; set; }

        public IEntityCollection<ITransaction> Transactions { get; set; }

        public IEntityCollection<IDownload> Downloads { get; set; }
    }
}
