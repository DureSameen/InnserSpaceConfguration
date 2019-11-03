using System;
using System.Collections.Generic;
using System.Text;

namespace InnerSpace.Domain.Aggregates.ConfigurationAggregate
{
    public class Configuration : BaseEntity
    {
        public string Name { get; private set; }
        public bool Enabled { get; private set; }
        protected Configuration()
        {
            //
        }

        public static Configuration Create(string name, bool enabled)
        {
            Configuration configuration = new Configuration { Name = name, Enabled = enabled };

            return configuration;
        }

        public void Edit(string name, bool enabled)
        {
            Name = name;
            Enabled = enabled;
        }
    }
}
 
