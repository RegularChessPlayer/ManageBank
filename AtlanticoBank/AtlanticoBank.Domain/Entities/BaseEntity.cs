using Flunt.Notifications;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AtlanticoBank.Domain.Entities
{
    public abstract class BaseEntity<TKeyType> : Notifiable
    {
        protected BaseEntity(TKeyType id = default)
        {
            Id = id;
        }

        public virtual TKeyType Id { get; set; }

        [JsonIgnore]
        public IReadOnlyCollection<Notification> Notifications { get; }
    }
}
