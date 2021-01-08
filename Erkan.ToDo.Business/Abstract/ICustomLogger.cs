using System;
using System.Collections.Generic;
using System.Text;

namespace Erkan.ToDo.Business.Abstract
{
    public interface ICustomLogger
    {
        public void LogError(string message);
    }
}
