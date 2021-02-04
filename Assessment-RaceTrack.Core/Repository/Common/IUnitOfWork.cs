using Microsoft.EntityFrameworkCore;
using MyHomeDoor.Core.Data;
using MyHomeDoor.Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHomeDoor.Core.Repository.Common
{
    public interface IUnitOfWork
    {
        MyDoorStepDBContext DBContext { get; }

        void Commit();
    }
}
