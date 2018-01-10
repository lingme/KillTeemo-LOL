using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.RabbitMQ
{
    public class OperationType
    {
        public enum Operation
        {
            update_web_site,
            log,
            feedback,
            mail,
            api
        }

        public static readonly string Mq_queue_name = "killteemo_queue";
    }
}
